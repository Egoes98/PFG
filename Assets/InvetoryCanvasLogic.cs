using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetoryCanvasLogic : MonoBehaviour
{
    GameObject description = null;

    public GameObject clues_panel;
    public GameObject obj_panel;

    public List<GameObject> descriptions;

    public GameObject dummy_selector;

    public void ChangeDescription(string name)
    {
        if (description != null) Destroy(description);
        switch (name)
        {
            default:
                description = descriptions[0];
                break;
        }
        Instantiate(description,this.transform);
    }

    public void CluesPanel()
    {
        if (clues_panel.activeSelf) return;
        obj_panel.SetActive(false);
        clues_panel.SetActive(true);
    }

    public void Objpanel()
    {
        if (obj_panel.activeSelf) return;
        clues_panel.SetActive(false);
        obj_panel.SetActive(true);
    }

    public void AddObject(string name)
    {
        GameObject obj_selector;
        obj_selector = Instantiate(dummy_selector, obj_panel.transform);
        dummy_selector.GetComponent<ActivateDescription>().setName(name);
        dummy_selector.GetComponent<ActivateDescription>().setICL(this.gameObject);
    }

    public void AddClue(string name)
    {
        GameObject obj_selector;
        obj_selector = Instantiate(dummy_selector, clues_panel.transform);
        dummy_selector.GetComponent<ActivateDescription>().setName(name);
        dummy_selector.GetComponent<ActivateDescription>().setICL(this.gameObject);
    }
}
