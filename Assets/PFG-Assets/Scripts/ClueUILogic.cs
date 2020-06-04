using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Globalization;
using System.Runtime.CompilerServices;

public class ClueUILogic : MonoBehaviour
{
    [Header("Notifications")]
    public Text notificationText;

    [Header("Clues Logic")]
    public int totalClues;
    public Text totalCluesText;
    int collectedClues;
    public Text collectedCluesText;

    // Start is called before the first frame update
    void Start()
    {
        totalCluesText.text = "" + totalClues;
    }

    public void addClues(string name)
    {
        if (collectedClues == totalClues) return;
        collectedClues++;
        collectedCluesText.text = collectedClues + "";
        notificationText.text = "Pista " + name + " adquirida";
        StartCoroutine("showNotifications");
    }

    public void ObjectAdquired(string name)
    {
        notificationText.text = "Objeto "+ name +" adquirido";
        StartCoroutine("showNotifications");
    }

    IEnumerator showNotifications()
    {
        notificationText.enabled = true;
        yield return new WaitForSeconds(2);
        notificationText.enabled = false;
    }
}
