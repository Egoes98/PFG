using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInteraction : MonoBehaviour
{
    public UnityEvent activate;
    public cakeslice.Outline outline;
    bool lookingAt;
    Transform camera;

    void Start()
    {
        camera = Camera.main.transform;
        lookingAt = false;
        outline.enabled = false;
    }

    public void isLooking(bool l)
    {
        lookingAt = l;
    }

    void Update()
    {
        if (lookingAt)
        {
            outline.enabled = true;
            if(Input.GetMouseButtonDown(0))
            {
                outline.enabled = false;
                activate.Invoke();
            }
        }
        else
        {
            outline.enabled = false;
        }
    }
}