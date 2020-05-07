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

   public void goToVictimRoom()
    {
        StartCoroutine(move());
    }

    IEnumerator move()
    {
        lD.CloseDoor();
        string actualLocation = gM.getLocation();
        gM.setLocation("Lift");
        yield return new WaitForSeconds(10);
        print(gM.getLocation());
        if (string.Compare(actualLocation, "Reception") == 0)
        {
            //SceneManager.LoadScene("VictimsRoom");
            gM.setLocation("VictimsRoom");
        }
        else
        {
            print("Moving to Reception");
           // SceneManager.LoadScene("Reception");
            gM.setLocation("Reception");
        }
    }
}
