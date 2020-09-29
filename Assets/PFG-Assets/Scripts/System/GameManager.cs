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
    public GameObject inventoryCanvas;
    public Inventory inv;
    public SceneLoader sL;
    MouseMode mouse_mode;

    public GameObject UI_overlay;

    static public bool inMenu = false;

    void Awake()
    {
        location = "Reception";
    }

    void Start()
    {
        audioManager.Play("ReceptionMusic");
        mouse_mode = Camera.main.GetComponent<MouseMode>();
    }

    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            UI_overlay.SetActive(false);
            inventoryCanvas.SetActive(true);
            mouse_mode.Enter();
            player.gameObject.SetActive(false);
            inMenu = true;
        }
        if (Input.GetKeyDown("escape") & inMenu)
        {
            inMenu = false;
            UI_overlay.SetActive(true);
            inventoryCanvas.SetActive(false);
            player.gameObject.SetActive(true);
            mouse_mode.Exit();
        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if(mouse_mode == null)
        {
            mouse_mode = Camera.main.GetComponent<MouseMode>();
        }
    }

    public bool HaveClues() 
    {
        return !inv.checkClues();
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
                    sL.LoadScene(3);
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
