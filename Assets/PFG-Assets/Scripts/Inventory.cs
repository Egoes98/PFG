using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string,bool> clues = new Dictionary<string, bool>();
    public Dictionary<string, bool> objects = new Dictionary<string, bool>();

    public ClueUILogic cUIL;

    public InvetoryCanvasLogic iCL;

    void Awake()
    {
        //Clues
        clues.Add("Reloj",false);
        clues.Add("Dinero", false);
        clues.Add("Cuerpo", false);
        clues.Add("Nota1", false);
        clues.Add("Nota2", false);

        //Objects
        objects.Add("Tarjeta",false);           //To open the door
        objects.Add("bottle_red", false);       //To bottle minigame
        objects.Add("bottle_green", false);     //To bottle minigame
        objects.Add("bottle_blue", false);      //To bottle minigame
        objects.Add("Acido", false);            //To break seal
        objects.Add("Llave Armario", false);    //To open Closet
    }

    public void addClue(string key)
    {
        bool own = true;
        clues.TryGetValue(key, out own);
        if (own) return;
        clues[key] = true;
        cUIL.addClues(key);
        iCL.AddClue(key);
    }
    public void addObject(string key)
    {
        bool own = true;
        objects.TryGetValue(key, out own);
        if (own) return;
        objects[key] = true;
        cUIL.ObjectAdquired(key);
        iCL.AddObject(key);
    }
    public bool checkObject(string key)
    {
        bool own = false;
        objects.TryGetValue(key, out own);
        if (own)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool checkClues(string key)
    {
        bool own = false;
        clues.TryGetValue(key, out own);
        if (own)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
