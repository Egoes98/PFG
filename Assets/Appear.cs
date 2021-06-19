using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{

    Material objectMaterial;

    // Start is called before the first frame update
    void Start()
    {
        objectMaterial = gameObject.GetComponent<Renderer>().material;
        Invoke("FadeIn", 2);
    }

    void FadeIn()
    {
        Color color = objectMaterial.color;
        for(float a = 0; a < 0; a = a + 0.01f)
        {
            color.a = 0.1f;
            objectMaterial.SetColor("_Color", color);
        }
        color.a = 1f;
        objectMaterial.SetColor("_Color", color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
