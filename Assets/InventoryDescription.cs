using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDescription : MonoBehaviour
{
    public Text description_text;
    public Text description_tittle;
    public Image description_image;

    public void SetText(string text)
    {
        description_text.text = text;
    }

    public void SetTittle(string name)
    {
        description_tittle.text = name;
    }

    public void SetPhoto(Sprite image)
    {
        description_image.color = new Color32(255, 255, 225, 255);
        description_image.sprite = image;
        description_image.SetNativeSize();
    }
}
