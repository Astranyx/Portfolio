using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2
{
   
    public enum ItemType
    {
        HealthPotion,
        ManaPotion,
        Coin,
        Sword,
    }

    public ItemType itemType;
    public int amount; 


    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword:        return ItemAssets.Instance.swordSprite;
            case ItemType.Coin:         return ItemAssets.Instance.coinSprite;
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
            case ItemType.ManaPotion:   return ItemAssets.Instance.manaPotionSprite;
        }
    }
}
