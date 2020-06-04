using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    public GameObject obj;

    public void enable()
    {
        if(obj != null) obj.SetActive(true);
    }
}
