using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialLogic : MonoBehaviour
{
    int dialState;

    void Start()
    {
        dialState = 1;
    }
    
    public void InteractDial()
    {
        transform.Rotate(0, 90, 0);
        changeState();
    }
    
    public void changeState()
    {
        if(dialState == 4)
        {
            dialState = 1;
        }
        else
        {
            dialState++;
        }
    }

    public int getState()
    {
        return dialState;
    }
}
