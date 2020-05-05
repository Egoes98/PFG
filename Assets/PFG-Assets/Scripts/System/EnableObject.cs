using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    public GameObject obj;

    public void enable()
    {
        obj.SetActive(true);
    }
}
