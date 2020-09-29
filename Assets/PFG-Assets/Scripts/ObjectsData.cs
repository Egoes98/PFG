using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsData : MonoBehaviour
{
    public string name;
    [Range(0, 1)]
    public int type; //1-Clue 0-Usable Object

    Inventory inv;

    void Awake()
    {
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    public void Found()
    {
        if (type == 1)
        {
            ManageClue();
        }
        else
        {
            ManageObject();
        }
    }

    void ManageClue()
    {
        inv.addClue(name);
    }

    void ManageObject()
    {
        inv.addObject(name);
    }
}