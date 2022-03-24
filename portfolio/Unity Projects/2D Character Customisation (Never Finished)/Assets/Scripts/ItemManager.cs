using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerData GlobalData;
    [SerializeField] GameObject CurrencyText = null;
    TextMeshProUGUI Text;

    public bool UpdateLook = false;



    void Awake()
    {
        Text = CurrencyText.GetComponent<TextMeshProUGUI>();

        OnCurrencyChanged += ItemManager_OnCurrencyChanged;
        Load();
    }

    private void ItemManager_OnCurrencyChanged(MonoBehaviour sender, int newValue)
    {
        if (Text is null) return;

        CurrencyText.GetComponentInChildren<TextMeshProUGUI>().text = newValue.ToString(); 
    }

    internal List<OutfitPiece> GetOwnedOutfitPiecesBySlot(string equipment_type)
    {
        return GlobalData.UnlockedPieces.Where(x => x.GetSlot() == equipment_type && x.IsOwned()).ToList();
    }

    public delegate void CurrencyChangedHandler(MonoBehaviour sender, int newValue);
    public event CurrencyChangedHandler OnCurrencyChanged;

    public void Load()
    {
        GlobalData = IOHelper.Read();
        ModifyCurrency(0); 
    }

    public void Save()
    {
        IOHelper.Write(GlobalData);
    }

    public int GetCurrency() { return GlobalData.Currency; }
    public void ModifyCurrency(int change) 
    {
        GlobalData.Currency += change;
        if (OnCurrencyChanged != null)
            OnCurrencyChanged.Invoke(this, GlobalData.Currency);
    }

    public string GetEquipment() { return GlobalData.Equipment; }
    public void SetEquipment(string newEquipment) { GlobalData.Equipment = newEquipment; }
    
    public List<OutfitPiece> GetOutfitPieces() { return GlobalData.UnlockedPieces; }
    public List<OutfitPiece> GetOutfitPiecesBySlot(string equipmentType) { return GlobalData.UnlockedPieces.Where(x => x.GetSlot() == equipmentType).ToList(); }

    public void ChangeOwnedStatusById(int id, bool owned) { GlobalData.UnlockedPieces.First(x => x.GetId() == id).SetOwned(owned); }

    internal bool IsEquipped(OutfitPiece outfitPiece) { return GlobalData.Equipment.Split(',').Any(x => x == outfitPiece.GetId().ToString()); }

    internal OutfitPiece GetItemById(string id) { return GlobalData.UnlockedPieces.FirstOrDefault(x => x.GetId().ToString() == id); }
}
