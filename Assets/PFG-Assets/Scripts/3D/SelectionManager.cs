using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Camera cam;
    GameObject previousObject;

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5f))
        {
            if (hit.transform.tag == "Interactable")
            {
                GameObject obj = hit.transform.gameObject;
                obj.GetComponent<ObjectInteraction>().isLooking(true);
                previousObject = obj;
            }
            else
            {
                if (previousObject != null)
                {
                    previousObject.GetComponent<ObjectInteraction>().isLooking(false);
                }
            }
        }
    }
}
