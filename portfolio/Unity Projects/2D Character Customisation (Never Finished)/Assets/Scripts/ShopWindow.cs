using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
    [Header("Sprite to change")]
    public SpriteRenderer bodyPart;
    [Header("Sprites to Cycle Through")]
    public GameObject PurchaseButton;
    public GameObject ItemManagerGO;
    public GameObject PreviewSprite;
    private ItemManager ItemManager;

    public string equipment_type;
    List<OutfitPiece> options;


    private int currentOption = 0;

    private void Start()
    {
        ItemManager = ItemManagerGO.GetComponent<ItemManager>();

        options = ItemManager.GetOutfitPiecesBySlot(equipment_type);
        OnOptionChanged();
    }


    public void NextOption()
    {
        currentOption++;
        if (currentOption >= options.Count)
        {
            currentOption = 0; // Restarts Cycle.
        }
        OnOptionChanged();
    }

    private void SetButtonText(string v)
    {
        PurchaseButton.GetComponentInChildren<TextMeshProUGUI>().text = v;
    }

    private void OnOptionChanged()
    {
        bodyPart.sprite = options[currentOption].GetSprite();
        if (options[currentOption].IsOwned())
        {
            SetButtonText("Sell");
        }
        else
        {
            SetButtonText("Buy");
        }

        PreviewSprite.GetComponent<Image>().sprite = bodyPart.sprite;
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

    public void HandlePurchase()
    {
        OutfitPiece piece = options[currentOption];

        if (PurchaseButton.GetComponentInChildren<TextMeshProUGUI>().text == "Buy")
        {
            if (ItemManager.GetCurrency() > piece.GetBuyPrice())
            {
                ItemManager.ModifyCurrency(-piece.GetBuyPrice());
                ItemManager.ChangeOwnedStatusById(piece.GetId(), true);

                options.First(x => x.GetId() == piece.GetId()).SetOwned(true);
                SetButtonText("Sell");
            }
        }
        else
        {
            if (options.Where(x => x.IsOwned()).Count() == 1) return;
            if (ItemManager.IsEquipped(piece)) return;

            ItemManager.ModifyCurrency(piece.GetSellPrice());
            ItemManager.ChangeOwnedStatusById(piece.GetId(), true);

            options.First(x => x.GetId() == piece.GetId()).SetOwned(false);
            SetButtonText("Buy");
        }

        ItemManager.Save();
    }
}
