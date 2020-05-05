using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInteraction : MonoBehaviour
{
    public UnityEvent activate;
    bool lookingAt;

    void Start()
    {
        lookingAt = false;
    }

    void Update()
    {
        if (lookingAt && Input.GetKeyDown(KeyCode.E))
        {
            activate.Invoke();
        }
    }

    public void isLooking(bool looking)
    {
        lookingAt = looking;
    }
}
