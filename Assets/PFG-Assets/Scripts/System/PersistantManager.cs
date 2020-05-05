using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantManager : MonoBehaviour
{
    public List<GameObject> persistantObjects;

    void Awake()
    {
        foreach (GameObject g in persistantObjects)
        {
            DontDestroyOnLoad(g);
        }
    }
}
