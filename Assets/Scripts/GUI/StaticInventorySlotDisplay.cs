using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inventory;
using UnityEngine.InputSystem;
using Keyparas;

public class StaticInventorySlotDisplay : InventorySlotDisplay
{
    //=====定義領域=====
    //キー配置のクラス
    KeyParameter parasKey;
    [SerializeField] private InventoryHolder inventoryHolder;
    public InventorySlotUI [] slots;
    protected override void Start()
    {
        //キー配置の読み込み
        parasKey = new KeyParameter();
        base.Start();
        if (inventoryHolder != null)
        {
            inventorySystem = inventoryHolder.PrimaryInventorySystem;
            inventorySystem.OnInventorySystemSlotChanged += UpdateSlot;
        }
        else Debug.LogWarning($"No inventory assigned to {this.gameObject} ");

        AssignSlot(inventorySystem);

        selectSlot = 0;
        preselectSlot = 0;
        slots[selectSlot].SelectSlot();
    }
    public override void AssignSlot(InventorySystem invToDisplay)
    {
        slotDictionary = new Dictionary<InventorySlotUI, ItemSystem>();

        if (slots.Length != inventorySystem.InventorySystemSize) Debug.Log($"Inventory Slots out of sync on {this.gameObject}");

        for (int i = 0; i < inventorySystem.InventorySystemSize; i++)
        {
            slotDictionary.Add(slots[i], inventorySystem.ItemSystems[i]);
            slots[i].Init(inventorySystem.ItemSystems[i]);
        }
    }
    void Update()
    {
        var current_mouseScroll = Mouse.current.scroll.ReadValue();
        if (current_mouseScroll != Vector2.zero)
        {
            preselectSlot = selectSlot;
            slots[preselectSlot].DeselectSlot();
            var moveSlot = current_mouseScroll.y < 0 ? -1 : 1;
            selectSlot = (selectSlot + moveSlot) % slots.Length < 0 ? slots.Length+(selectSlot + moveSlot) % slots.Length: (selectSlot + moveSlot) % slots.Length;
            slots[selectSlot].SelectSlot();

        }
        //-----モノを捨てる-----
        if (Input.GetKeyDown(parasKey.drop))
        {
            DropInventoryItem(selectSlot);
        }
    }
    public void DropInventoryItem(int selectSlot)
    {
        if (!inventoryHolder) return;
        if (inventoryHolder.PrimaryInventorySystem.RemoveToInventorySystem(selectSlot, 1))
        {
            slots[selectSlot].UpdateUISlot();
        }
    }
}
