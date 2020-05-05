using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDuplicate : MonoBehaviour
{
    public string tag;
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag(tag).Length == 2)
        {
            Destroy(this.gameObject);
        }
    }
}
