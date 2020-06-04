using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ObjectChecking : MonoBehaviour
{
    public List<string> requiredObjects;
    Inventory inv;
    bool rFulfilled;

    public GameObject actionTarget;
    public string action;
    public AudioSource aS;

    void Awake()
    {
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    public void checkRequirements()
    {
        foreach (string s in requiredObjects)
        {
            if (inv.checkObject(s))
            {
                if (aS != null) aS.Play();
                rFulfilled = true;
            }
            else
            {
                rFulfilled = false;
                break;
            }
        }

        print(rFulfilled);
        if (rFulfilled)
        {
            actionTarget.SendMessage(action);
        }
    }
}
