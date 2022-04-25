using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Item_Match3 : MonoBehaviour
{


    public GameObject imageItem;
    public int x;
    public int y;
    public int cost;
    public Sprite image;

    public void SetComponents(int x, int y, int cost, Sprite image)
    {
        this.x = x;
        this.y = y;
        this.cost = cost;
        this.image = image;

        imageItem.GetComponent<Image>().sprite = image;
    }

    public void ChangeImage(Sprite image)
    {
        this.image = image;

        imageItem.GetComponent<Image>().sprite = image;
    }
}
