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

    [Header("Interaction Hints")]
    public GameObject description;
    public GameObject interactionHints;

    [Header("Description Logic")]
    public Descriptions desc;
    public Text desc_text_displayer;
    public Text desc_tittle_displayer;

    // Start is called before the first frame update
    void Start()
    {
        totalCluesText.text = "" + totalClues;
    }

    public void OnInteractionHints(string name)
    {
        ChangeDescription(name);
        interactionHints.SetActive(true);
    }

    public void OfInteractionHints()
    {
        interactionHints.SetActive(false);
    }

    void ChangeDescription(string name)
    {
        desc_tittle_displayer.text = name;
        desc_text_displayer.text = desc.GetDescription(name);
    }

    public void TurnOffDescription()
    {
        description.SetActive(false);
    }

    public void ChangeDescriptionState()
    {
        if (description.activeSelf)
        {
            description.SetActive(false);
        }
        else
        {
            description.SetActive(true);

        }
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
