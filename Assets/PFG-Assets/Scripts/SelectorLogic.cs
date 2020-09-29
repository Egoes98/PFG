using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectorLogic : MonoBehaviour
{
    InvetoryCanvasLogic iCL;

    void Start()
    {
        iCL = GameObject.FindGameObjectWithTag("Inventory_canvas").GetComponent<InvetoryCanvasLogic>();
    }
    public void setName(string n)
    {
        GetComponentInChildren<Text>().text = n;
    }
     
    public void SetDescription()
    {
        iCL.ChangeDescription(GetComponentInChildren<Text>().text);
    }
}
