using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActivateDescription : MonoBehaviour
{
    private string name;
    private GameObject iCL;

    public void setICL(GameObject gO)
    {
        iCL = gO;
    }

    public void setName(string n)
    {
        name = n;
        GetComponentInChildren<Text>().text = name;
        this.gameObject.name = name + "_selector";
    }
     
    public void SetDescription()
    {
        if (iCL == null) print("NULL");
        iCL.GetComponent<InvetoryCanvasLogic>().ChangeDescription(name);
    }

    void Update()
    {
        print(name);
    }


}
