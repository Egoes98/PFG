using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetoryCanvasLogic : MonoBehaviour
{
    [Header("Panels")]
    public GameObject clues_panel;
    public GameObject obj_panel;

    [Header("Selector & Descriptions Prefabs")]
    public GameObject description_dummy;
    public GameObject dummy_selector;

    [Header("Descriptions")]
    public Descriptions desc;

    public void ChangeDescription(string name)
    {
        description_dummy.GetComponent<InventoryDescription>().SetText(desc.GetDescription(name));
        description_dummy.GetComponent<InventoryDescription>().SetTittle(name);
        description_dummy.GetComponent<InventoryDescription>().SetPhoto(desc.GetPhotos(name));
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
        obj_selector.GetComponent<SelectorLogic>().setName(name);
    }

    public void AddClue(string name)
    {
        GameObject obj_selector;
        obj_selector = Instantiate(dummy_selector, clues_panel.transform);
        obj_selector.GetComponent<SelectorLogic>().setName(name);
    }
}
