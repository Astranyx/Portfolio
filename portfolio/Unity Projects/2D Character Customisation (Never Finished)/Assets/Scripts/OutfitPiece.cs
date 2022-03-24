using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitPiece
{
    [SerializeField] private int _id;
    [SerializeField] private Sprite _img;
    [SerializeField] private bool _owned;
    [SerializeField] private int _buyPrice;
    [SerializeField] private string _slot;

    public OutfitPiece(int id, Sprite sprite, int buyPrice, string slot, bool owned)
    {
        this._id = id;
        this._img = sprite;
        this._buyPrice = buyPrice;
        this._slot = slot;
        this._owned = owned;
    }

    internal string GetSlot() { return _slot; }

    public int GetId() { return _id; }
    public Sprite GetSprite() { return _img; }
    public bool IsOwned() { return _owned; }
    public int GetBuyPrice() { return _buyPrice; }
    public int GetSellPrice() { return Mathf.RoundToInt(_buyPrice * 0.7f); }

    internal void SetOwned(bool owned)
    {
        _owned = owned;
    }
}
