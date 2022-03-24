using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    private Item? _containingItem;
    private bool _locked;
    public InventorySlot()
    {
        _containingItem = null;
        _locked = false;
    }

    public Item Item { get { return _containingItem; } }
    public bool IsEmpty() { return Item is null; }
    public void SetItem(Item newItem) { _containingItem = newItem; }
    public void RemoveItem() { _containingItem = null; }

    public void Lock(bool apply) { _locked = apply; }
    public bool IsLocked() { return _locked; }
}
