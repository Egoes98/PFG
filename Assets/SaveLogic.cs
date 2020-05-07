using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLogic : MonoBehaviour
{
    [Header("Password Settings")]
    public string password;
    public int passwordLong;

    [Header("References")]
    public Camera cam;
    GameObject player;
    public Text inputPannel;
    public Canvas c;
   
    string input;
    bool open;

    void Start()
    {
        open = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //When interacted call this method
    public void UseSafe()
    {
        if (open) return;
        player.SetActive(false);
        cam.enabled = true;
        c.enabled = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ButtonClicked(string i)
    {
        if (open) return;
        input = input + i;
        print(input);
        if(input.Length == passwordLong){
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
            cam.enabled = false;
            c.enabled = false;
            player.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
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
