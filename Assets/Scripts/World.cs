using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
    public Texture2D image;
    public GameObject gamePixel;

    public static int selectedColor = 1;
    public static List<Color> colors;

    private Dictionary<Color, List<Tuple<int, int>>> legend;

    private void Start()
    {
        this.legend = new Dictionary<Color, List<Tuple<int, int>>>();
        colors = new List<Color>();

        this.LoadImage();
        this.InstantiateImage();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            selectedColor = 1;
        else if (Input.GetKey(KeyCode.Alpha2))
            selectedColor = 2;
        else if (Input.GetKey(KeyCode.Alpha3))
            selectedColor = 3;
        else if (Input.GetKey(KeyCode.Alpha4))
            selectedColor = 4;
        else if (Input.GetKey(KeyCode.Alpha5))
            selectedColor = 5;
    }

    private void LoadImage()
    {
        // Load every non transparent pixel into the dictionary
        for (int i = 0; i < this.image.width; i++)
        {
            for (int j = 0; j < this.image.height; j++)
            {
                Color pixel = this.image.GetPixel(i, j);

                if (pixel.a == 1)
                {
                    if (!this.legend.ContainsKey(pixel))
                    {
                        List<Tuple<int, int>> new_list = new List<Tuple<int, int>>();
                        new_list.Add(new Tuple<int, int>(i, j));

                        this.legend.Add(pixel, new_list);
                        colors.Add(pixel);
                    }
                    else
                        this.legend[pixel].Add(new Tuple<int, int>(i, j));
                }
            }
        }
    }

    private void InstantiateImage()
    {
        for (int i = 0; i < colors.Count; i++)
        {
            for (int j = 0; j < this.legend[colors[i]].Count; j++)
            {
                // Spawn pixel so that the image is in the middle of the screen
                float x = (this.legend[colors[i]][j].Item1 - this.image.width / 2.0f) * 50.0f;
                float y = (this.legend[colors[i]][j].Item2 - this.image.height / 2.0f) * 50.0f;

                GameObject spawned_pixel = Instantiate(this.gamePixel, new Vector3(x, y, 0), Quaternion.identity, GameObject.Find("Canvas").transform);

                spawned_pixel.GetComponent<Image>().color = new Color(colors[i].r, colors[i].g, colors[i].b, 0.5f);
                spawned_pixel.GetComponent<Pixel>().number = i + 1;
            }
        }
    }
}
