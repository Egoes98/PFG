using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class InventoryCheck : MonoBehaviour
{
    public List<string> items;

    void Start()
    {
        items = new List<string>();
        items.Add("Prueba");
    }

    public bool haveItem(string item)
    {
        if (items == null) return false;
        if (items.Contains(item)) return true;
        return false;
    }

    public void addItems(string item)
    {
        print("ADD "+item);
        items.Add(item);
    }
}
