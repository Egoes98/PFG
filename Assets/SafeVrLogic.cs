using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeVrLogic : MonoBehaviour
{
    [Header("Password Settings")]
    public string password;
    public int passwordLong;

    [Header("References")]
    public ManageInput mI;

    string input;
    bool open;

    void Start()
    {
        open = false;
    }

    public void ButtonClicked(string i)
    {
        if (open) return;
        input = input + i;
        if (input.Length == passwordLong)
        {
            open = true; //Put it on open for now so buttons doesnt work
            Check();
        }
    }

    void Check()
    {
        //Check to see if password is correct
        if (string.Compare(password, input) == 0)
        {
            print("OPEN");
            //Play sound
            //OpenDoor
        }
        else
        {
            print("CLOSED");
            open = false; //Chnage the state o show it isnt open
            //Clear Text
            //Play error sound
            //TODO
            return;
        }
    }
}
