using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;
    string location;
    Transform player;
    public List<Vector3> playerPos;
    public SceneLoader sL;

    void Awake()
    {
        location = "Reception";
    }

    void Start()
    {
        audioManager.Play("ReceptionMusic");
    }

    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public void setLocation(string l)
    {
        if (location != l)
        {
            location = l;
            switch (location)
            {
                case "Reception":
                    playerPos[1] = player.position;
                    sL.LoadScene(0);
                    break;
                case "VictimsRoom":
                    playerPos[0] = player.position;
                    sL.LoadScene(1);
                    break;
                case "Lift":
                    audioManager.StopSound();
                    audioManager.Play("LiftMusic");
                    break;
            }
        }
    }

    public void AfterLoaded()
    {
        switch (location)
        {
            case "Reception":
                audioManager.StopSound();
                audioManager.Play("ReceptionMusic");
                break;
            case "VictimsRoom":
                audioManager.StopSound();
                audioManager.Play("RoomMusic");
                break;
            default:
                break;
        }
    }

    public Vector3 getPos()
    {
        switch (location)
        {
            case "Reception":
                return playerPos[0];
                break;
            case "VictimsRoom":
                return playerPos[1];
                break;
            default:
                return new Vector3(0,0,0);
                break;
        }
    }

    public string getLocation()
    {
        return location;
    }

    
}
