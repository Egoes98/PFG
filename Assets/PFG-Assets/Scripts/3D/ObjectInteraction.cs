using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInteraction : MonoBehaviour
{
    public UnityEvent activate;
    public UnityEvent activate_first_time;
    public cakeslice.Outline outline;
    bool lookingAt;
    bool firstTime;

    void Start()
    {
        lookingAt = false;
        if (outline != null) outline.enabled = false;
        firstTime = false;
    }

    public void isLooking(bool l)
    {
        lookingAt = l;
    }

    void Update()
    {
        if (GameManager.inMenu) return;
        if (lookingAt)
        {
            if (outline != null) outline.enabled = true;
            if(Input.GetMouseButtonDown(0))
            {
                if (outline != null) outline.enabled = false;
                activate.Invoke();
                if (!firstTime & activate_first_time != null)
                {
                    activate_first_time.Invoke();
                }
                firstTime = true;
            }
        }
        else
        {
            if (outline == null) return;
            outline.enabled = false;
        }
    }
}