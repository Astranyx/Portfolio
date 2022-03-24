using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    private string _name;
    private Sprite _icon;
    private float _merchantPrice;

    public string GetName() => _name;
    public Sprite GetIcon() => _icon;
    public float GetPrice() => _merchantPrice;
    public float GetSellPrice() => _merchantPrice * 0.7f;
}
