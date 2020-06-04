using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMode : MonoBehaviour
{
    public GameObject player;
    public GameObject redDot;

    public void Enter()
    {
        GetComponent<CameraLook>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        redDot.SetActive(false);
        
    }

    public void Exit()
    {
        GetComponent<CameraLook>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        redDot.SetActive(true);
    }
}
