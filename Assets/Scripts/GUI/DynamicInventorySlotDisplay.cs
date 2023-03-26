using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using inventory;

public class DynamicInventorySlotDisplay : InventorySlotDisplay
{
    [SerializeField] protected InventorySlotUI slotPrefab;
    protected override void Start()
    {
        //InventoryHolder.OnInventorySystemRequested += RefreshDynamicInventory;
        base.Start();

    }
    public void RefreshDynamicInventory(InventorySystem invToDisplay)
    {
        ClearSlot();
        inventorySystem = invToDisplay;
        //UpdateSlot‚ð“o˜^‚·‚é
        if(inventorySystem != null) inventorySystem.OnInventorySystemSlotChanged += UpdateSlot;
        AssignSlot(invToDisplay);
    }
    public override void AssignSlot(InventorySystem invToDisplay)
    {
        ClearSlot();
        slotDictionary = new Dictionary<InventorySlotUI, ItemSystem>();

        if (invToDisplay == null) return;

        for (int i = 0; i < invToDisplay.InventorySystemSize; i++)
        {
            var uiSlot = Instantiate(slotPrefab, transform);
            slotDictionary.Add(uiSlot, invToDisplay.ItemSystems[i]);
            uiSlot.Init(inventorySystem.ItemSystems[i]);
        }
    }
    private void ClearSlot()
    {
        foreach (var item in transform.Cast<Transform>())
        {
            Destroy(item.gameObject);
        }
        if (slotDictionary != null) slotDictionary.Clear();
    }
    private void OnDisabled()
    {
        if (inventorySystem != null) inventorySystem.OnInventorySystemSlotChanged -= UpdateSlot;
    }
}
