using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nuke : MonoBehaviour
{
    Image image;

    Color colour;

    // Use this for initialization
    void Start()
    {
        //Finding the Petrification Image
        image = GetComponent<Image>();

        colour = image.color;
    }


    //Used to get and set colour
    public void Color(Color color)
    {
        image.GetComponent<SpriteRenderer>().color = color;
    }

    // Update is called once per frame

    //Changes spell to black when charge is higher than 1
    void Update()
    {
        if (PlayerStats.currentCharge <= 0 || PlayerStats.canNuke == false || CameraController.canDet == false)
        {
            image.color = new Color(0f, 0f, 0f, 0f);
        }
        else
        {
            image.color = colour;
        }

    }
}
