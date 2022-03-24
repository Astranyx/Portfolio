using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    // Private Members
    private int _inventoryRows;
    private int _inventoryColumns;

    private float _moneyValue;
    private InventorySlot[,] _inventorySlots;
    [SerializeField] private GameObject _gridObject;

    // Events
    public delegate void MoneyChangedHandler(MonoBehaviour sender, float newValue);
    public event MoneyChangedHandler OnMoneyChanged;

    private void Awake()
    {
        _inventoryColumns = 6;
        _inventoryRows = 2;

        _moneyValue = 1000.0f;

        _inventorySlots = new InventorySlot[_inventoryRows, _inventoryColumns];
    }

    private void Start()
    {
        int height = 0;
        int width = 0;


        for (int x = 0; x < _inventoryRows; x++)
        {
            for (int y = 0; y < _inventoryColumns; y++)
            {
                _inventorySlots[x, y] = new InventorySlot();

                Instantiate(_gridObject, new Vector3(transform.position.x + width, transform.position.y + height), Quaternion.identity, gameObject.transform);
                width += 32;
            }
            height += 32;
            width = 0;
        }
    }


    public bool CanAfford(float itemPrice) => _moneyValue > itemPrice;
    public void ModifyMoney(float change)
    {
        _moneyValue += change;
        OnMoneyChanged?.Invoke(this, _moneyValue);
    }

    public InventorySlot? GetNextInventorySlot()
    { 
        for (int x = 0; x < _inventoryRows; x++)
        {
            for (int y = 0; y < _inventoryColumns; y++)
            {
                if (_inventorySlots[x, y].IsEmpty() && !_inventorySlots[x, y].IsLocked())
                {
                    return _inventorySlots[x, y];
                }
            }
        }

        return null;
    }

    public InventoryChangeResult SwapSlots(InventorySlot is1, InventorySlot is2)
    {
        if (is1.IsEmpty()) return InventoryChangeResult.INVENTORY_CHANGE_INTERNAL_ERROR;

        is1.Lock(true);
        is2.Lock(true);

        Item tmp = is2.Item;
        is2.SetItem(is1.Item);
        is1.SetItem(tmp);

        is1.Lock(false);
        is2.Lock(false);

        return InventoryChangeResult.INVENTORY_CHANGE_OK;
    }

    public InventoryChangeResult AddItem(Item newItem)
    {
        if (!CanAfford(newItem.GetPrice()))
        {
            return InventoryChangeResult.INVENTORY_CHANGE_INSUFFICIENT_MONEY;
        }

        InventorySlot? freeSlot = GetNextInventorySlot();
        if (freeSlot.IsLocked())
        {
            return InventoryChangeResult.INVENTORY_CHANGE_INTERNAL_ERROR;
        }

        try
        {
            freeSlot.Lock(true);
            freeSlot.SetItem(newItem);
            ModifyMoney(-newItem.GetPrice());
            freeSlot.Lock(false);
        }
        catch
        {
            return InventoryChangeResult.INVENTORY_CHANGE_INTERNAL_ERROR;
        }


        return InventoryChangeResult.INVENTORY_CHANGE_OK;
    }

    public InventoryChangeResult RemoveItem(int x, int y)
    {
        if (_inventorySlots[x, y].IsEmpty())
            return InventoryChangeResult.INVENTORY_CHANGE_ITEM_DOES_NOT_EXIST;

        if (_inventorySlots[x, y].IsLocked())
            return InventoryChangeResult.INVENTORY_CHANGE_INTERNAL_ERROR;

        try
        {
            InventorySlot slot = _inventorySlots[x, y];
            slot.Lock(true);
            ModifyMoney(slot.Item.GetSellPrice());
            slot.RemoveItem();
            slot.Lock(false);
            return InventoryChangeResult.INVENTORY_CHANGE_OK;
        }
        catch
        {
            return InventoryChangeResult.INVENTORY_CHANGE_INTERNAL_ERROR;
        }
    }
}
public enum InventoryChangeResult
{
    INVENTORY_CHANGE_OK,
    INVENTORY_CHANGE_INSUFFICIENT_MONEY,
    INVENTORY_CHANGE_NO_BAG_SLOTS,
    INVENTORY_CHANGE_INTERNAL_ERROR,
    INVENTORY_CHANGE_ITEM_DOES_NOT_EXIST
}
