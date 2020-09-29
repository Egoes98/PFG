using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Descriptions : MonoBehaviour
{
    TextAsset textfile;
    string textLines;

    public string GetDescription(string name)
    {
        LoadFile(name);
        LoadText();
        return textLines;
    }

    void LoadFile(string name)
    {
        string path = "TextFiles/"+name;
        textfile = Resources.Load<TextAsset>(path);
    }

    void LoadText()
    {
        if(textfile != null)
        {
            textLines = (textfile.text);
        }
    }

    public Sprite GetPhotos(string name)
    {
        string path = "GUI_images/Descriptions_photos/" + name;
        return Resources.Load<Sprite>(path);
    }
}
