using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pixel : MonoBehaviour
{
    public int number = 0;

    private bool isSet = false;

    private void Start()
    {
        this.transform.GetChild(0).gameObject.GetComponent<Text>().text = number.ToString();
    }

    private void OnMouseDown()
    {
        Color actual_color = World.colors[this.number - 1];

        if (World.selectedColor == this.number)
        {
            Color new_color = new Color(actual_color.r, actual_color.g, actual_color.b, 1.0f);

            if (!this.isSet)
            {
                this.gameObject.GetComponent<Image>().color = new_color;
                this.isSet = true;

                Destroy(this.transform.GetChild(0).gameObject);
            }
        }
        else
        {
            Color wrong_color = World.colors[World.selectedColor - 1];

            float r = (actual_color.r + wrong_color.r) / 2.0f;
            float g = (actual_color.g + wrong_color.g) / 2.0f;
            float b = (actual_color.b + wrong_color.b) / 2.0f;

            Color new_color = new Color(r, g, b, 0.5f);


            if (!this.isSet)
                this.gameObject.GetComponent<Image>().color = new_color;
        }
    }
}
