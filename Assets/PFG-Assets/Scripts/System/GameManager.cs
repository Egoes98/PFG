using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;
    string location;
    public List<Vector3> spawnLocations;
    public Transform player;

    void Start()
    {
        location = "Reception";
        print("Location START: " + location);
        audioManager.Play("ReceptionMusic");
    }

    public void setLocation(string l)
    {
        if (location != l)
        {
            location = l;
            if (string.Compare(location,"Reception") == 0)
            {
                audioManager.StopSound();
                audioManager.Play("ReceptionMusic");
                player.position = spawnLocations[0];
                SceneManager.LoadScene("Reception");
            }
            else if(string.Compare(location, "VictimsRoom") == 0)
            {
                audioManager.StopSound();
                audioManager.Play("RoomMusic");
                player.position = spawnLocations[1];
                SceneManager.LoadScene("VictimsRoom");
            }
            else
            {
                audioManager.StopSound();
                audioManager.Play("LiftMusic");
            }
        }
    }

    public string getLocation()
    {
        return location;
    }

    
}
