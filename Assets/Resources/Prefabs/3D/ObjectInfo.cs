using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCInfo : MonoBehaviour
{
    public string name;
    public bool saveObject;
    public bool destroyWhenTaken;
    [Range(0,1)]
    public int type; //1-Clue 0-Usable Object

    Inventory inv;

    void Awake()
    {
        //inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    public void Found()
    {
        Debug.Log("Interaccion");
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
        print("Has encontrado una pista");
        inv.addClue(name);
    }

    void ManageObject()
    {
        inv.addObject(name);
        if (destroyWhenTaken) Destroy(this);
    }
}
