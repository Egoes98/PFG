using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitLogic : MonoBehaviour
{
    public Rigidbody rb;
    public ObjectInteraction oI;

    void Start()
    {
        rb.useGravity = false;
    }

   public void Interact()
    {
        rb.useGravity = true;
        oI.enabled = false;
        
    }
}
