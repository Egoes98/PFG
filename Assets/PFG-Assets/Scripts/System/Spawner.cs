using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject toInstantiate;
    public Transform location;

    public void Instantiate()
    {
        Instantiate(toInstantiate, location.position, location.rotation);
        Destroy(this.gameObject);
    }
}
