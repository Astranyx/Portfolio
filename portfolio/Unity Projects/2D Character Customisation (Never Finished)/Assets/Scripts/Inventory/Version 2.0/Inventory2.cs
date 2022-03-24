using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2 {

    private List<Item2> itemList;

    public Inventory2()
    {
        itemList = new List<Item2>();

        AddItem(new Item2 { itemType = Item2.ItemType.HealthPotion, amount = 1 });
        AddItem(new Item2 { itemType = Item2.ItemType.ManaPotion, amount = 1 });
        AddItem(new Item2 { itemType = Item2.ItemType.Coin, amount = 1 });
    }

    public void AddItem(Item2 item)
    {
        itemList.Add(item);
    }

    public List<Item2> GetItemList()
    {
        return itemList;
    }
}