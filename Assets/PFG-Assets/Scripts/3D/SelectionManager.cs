using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Camera cam;
    GameObject interactedObj;

    void Update()
    {
        if(interactedObj != null)
        {
            interactedObj.GetComponent<ObjectInteraction>().isLooking(false);
            interactedObj = null;
        }

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1.5f))
        {
            if (hit.transform.tag == "Interactable")
            {
                interactedObj = hit.transform.gameObject;
                interactedObj.GetComponent<ObjectInteraction>().isLooking(true);
            }
        }
    }
}
