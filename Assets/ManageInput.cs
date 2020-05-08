using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageInput : MonoBehaviour
{
    public List<Mesh> numbers;
    public List<MeshFilter> visualSlots;
    public List<Mesh> slots;
    int characters;

    void Start()
    {
        characters = 0;
        //Cargar la lista de Slots con nada
    }

    public void ManageSlots(string n)
    {
        switch (n)
        {
            case "0":
                //cargar slot 0 con 0
                //Rotar posiciones
                break;
            case "1":
                //cargar slot 0 con 1
                //Rotar posiciones
                break;
            case "2":
                //cargar slot 0 con 2
                //Rotar posiciones
                break;
            case "3":
                //cargar slot 0 con 3
                //Rotar posiciones
                break;
            case "4":
                //cargar slot 0 con 4
                //Rotar posiciones
                break;
            case "5":
                //cargar slot 0 con 5
                //Rotar posiciones
                break;
            case "6":
                //cargar slot 0 con 6
                //Rotar posiciones
                break;
            case "7":
                //cargar slot 0 con 7
                //Rotar posiciones
                break;
            case "8":
                //cargar slot 0 con 8
                //Rotar posiciones
                break;
            case "9":
                //cargar slot 0 con 9
                //Rotar posiciones
                break;
        }
    }

    public void Clear()
    {
        numbers.Clear();
        foreach(Mesh m in slots)
        {
            //POner en blaco slots
        }
        foreach (MeshFilter m in visualSlots)
        {
            //POner en blanco VisualSlots
        }
    }
}
