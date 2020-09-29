using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;

    Vector3 prevObjPos;
    Quaternion prevObjRot;

    Rigidbody rb;
    MeshCollider mC;

    bool use;

    public float distance;
    public float smooth;

    public bool detroyWhenTaken;

    ClueUILogic clueUILogic;
    ObjectsData objData;

    void Start()
    {
        use = false;
        rb = GetComponent<Rigidbody>();
        mC = GetComponent<MeshCollider>();
        clueUILogic = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ClueUILogic>();
        objData = GetComponent<ObjectsData>();
    }


    public void Interact()
    {
        if (!use)
        {
            EnterViewMode();
        }
    }

    void EnterViewMode()
    {
        clueUILogic.OnInteractionHints(objData.name);
        prevObjPos = transform.position;
        prevObjRot = transform.rotation;

       GetComponent<ObjectInteraction>().enabled = false;

        Camera.main.gameObject.GetComponent<MouseMode>().Enter();
        if(mC != null) mC.enabled = false;

        Vector3 camerPos = Camera.main.transform.position;
        transform.position = Vector3.Lerp(transform.position, Camera.main.transform.forward * distance, Time.deltaTime * smooth);

        if(rb != null) rb.useGravity = false;
        use = true;
    }

    void ExitViewMode()
    {
        clueUILogic.OfInteractionHints();
        clueUILogic.TurnOffDescription();

        transform.position = prevObjPos;
        transform.rotation = prevObjRot;

        GetComponent<ObjectInteraction>().enabled = true;

        Camera.main.gameObject.GetComponent<MouseMode>().Exit();
        if (mC != null) mC.enabled = true;

        if (rb != null) rb.useGravity = true;
        use = false;
        if (detroyWhenTaken) Destroy(this.gameObject);
    }

    void Update()
    {
        if (use)
        {
            if (Input.GetMouseButtonDown(1))
            {
                ExitViewMode();
            }
            if (Input.GetKeyDown("e"))
            {
                clueUILogic.ChangeDescriptionState();
            }
            if (Input.GetMouseButton(0))
            {
                mPosDelta = Input.mousePosition - mPrevPos;
                transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
                transform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);
            }
            mPrevPos = Input.mousePosition;
        }
    }
}
