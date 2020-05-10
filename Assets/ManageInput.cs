using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManageInput : MonoBehaviour
{
    public List<Mesh> numbers;
    public List<MeshFilter> visualSlots;
    LinkedList<Mesh> slots = new LinkedList<Mesh>();
    Mesh none;

    void Start()
    {
        none = new Mesh();
        for (int i = 0;  visualSlots.Count > i; i++)
        {
            slots.AddFirst(none);
        }
    }

    public void ManageSlots(string n)
    {
        int number = Int32.Parse(n);
        slots.AddFirst(numbers[number]);
        slots.RemoveLast();

        LinkedListNode<Mesh> slotNode = slots.First;
        visualSlots[0].mesh = slotNode.Value;
        for (int i = 1; visualSlots.Count > i; i++)
        {
            visualSlots[i].mesh = slotNode.Next.Value;
            slotNode = slotNode.Next;
        }
    }

    public void Clear()
    {
        slots.Clear();
        for (int i = 0; visualSlots.Count > i; i++)
        {
            slots.AddFirst(none);
        }
        foreach (MeshFilter mF in visualSlots)
        {
            mF.mesh = none;
        }
    }
}
