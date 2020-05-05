using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Touch : MonoBehaviour
{
    public UnityEvent onTouch;
    public UnityEvent onFirstTouch;

    bool firstTouch;

    void Start()
    {
        firstTouch = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (firstTouch)
        {
            firstTouch = false;
            onFirstTouch.Invoke();
        }
        else
        {
            onTouch.Invoke();
        }
    }
}
