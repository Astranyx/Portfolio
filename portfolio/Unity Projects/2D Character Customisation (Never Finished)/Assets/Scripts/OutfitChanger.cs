using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitChanger : MonoBehaviour
{
    [Header("Sprite to change")]
    public SpriteRenderer bodyPart;
    [Header("Sprites to Cycle Through")]
    public GameObject ItemManagerGO;
    private ItemManager ItemManager;

    public string equipment_type;
    List<OutfitPiece> options;


    private int currentOption = 0;

    private void Start()
    {
        ItemManager = ItemManagerGO.GetComponent<ItemManager>();

        options = ItemManager.GetOwnedOutfitPiecesBySlot(equipment_type);
        OnOptionChanged();
    }

    public void UpdateSlot(string oldItem, string newItem)
    {
        ItemManager.SetEquipment(ItemManager.GetEquipment().Replace(oldItem, newItem));
    }

    public void NextOption()
    {
        string lastId = options[currentOption].GetId().ToString();

        currentOption++;
        if (currentOption >= options.Count)
        {
            currentOption = 0; // Restarts Cycle.
        }

        string newId = options[currentOption].GetId().ToString();

        OnOptionChanged();
        UpdateSlot(lastId, newId);
    }
    private void OnOptionChanged()
    {
        bodyPart.sprite = options[currentOption].GetSprite();
    }

    public void PreviousOption()
    {
        currentOption--;
        if (currentOption <= 0)
        {
            currentOption = options.Count - 1; // Restarts Cycle.
        }
        OnOptionChanged();
    }

    public void Randomize()
    {
        currentOption = Random.Range(0, options.Count);
        bodyPart.sprite = options[currentOption].GetSprite();
    }
}
