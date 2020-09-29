 using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiftMove : MonoBehaviour
{
    public DoorAnimationLogic lD;
    GameManager gM;

    void Start()
    {
        GameObject gMObject = GameObject.FindGameObjectWithTag("GameManager");
        gM = gMObject.GetComponent<GameManager>();
    }

   public void goToVictimRoom(string location)
    {
        StartCoroutine(move(location));
    }

    IEnumerator move(string location)
    {
        lD.CloseDoor();
        string actualLocation = gM.getLocation();
        gM.setLocation("Lift");
        yield return new WaitForSeconds(10);
        gM.setLocation(location);

    }
}
