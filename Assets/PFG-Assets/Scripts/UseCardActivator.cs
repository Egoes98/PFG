using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCardActivator : MonoBehaviour
{
    public GameObject iC;

    public void activate()
    {
        //Check if there is card in the inventory
        //You have the card
        //Play animation
        //Play sound
        //open lift door
        //You dont have it
        //Play sound
        if (iC.GetComponent<InventoryCheck>().haveItem("LiftCard"))
        {
            print("You have it");
        }
        else
        {
            print("You dont have it");
        }
    }
}
