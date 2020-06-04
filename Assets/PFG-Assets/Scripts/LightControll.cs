using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControll : MonoBehaviour
{
    public List<GameObject> lights;
    bool state;

    void Start()
    {
        state = false;
        foreach ( GameObject light in lights)
        {
            light.SetActive(false);
        }
    }

    public void changeState()
    {
        state = !state;
        foreach (GameObject light in lights)
        {
            light.SetActive(state);
        }
    }
}
