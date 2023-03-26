using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventorySlotDisplay : MonoBehaviour
{
    [SerializeField] private MouseItemData mouseItemData;
    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlotUI, ItemSystem> slotDictionary;

    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlotUI, ItemSystem> SlotDictionary => slotDictionary;

    //選択されたスロット
    public int selectSlot;
    //以前選択されたスロット
    public int preselectSlot;

    protected virtual void Start()
    {

    }

    public abstract void AssignSlot(InventorySystem invToDisplay);

    protected virtual void UpdateSlot(ItemSystem updateSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if (slot.Value == updateSlot)
            {
                slot.Key.UpdateUISlot(updateSlot);
            }
        }
    }

    public void SlotClicked(InventorySlotUI clickedUISlot)
    {
        //インベントリのアイテムがクリックされて-マウスが何のアイテムも持ってなかったら
        if (clickedUISlot.AssignedInventorySlot.ItemObject != null && mouseItemData.AssignedInventorySlot.ItemObject == null)
        {
            mouseItemData.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
            clickedUISlot.ClearSlot();
            return;
        }
        //インベントリが空で-マウスが何かアイテムを持っていたら
        if (clickedUISlot.AssignedInventorySlot.ItemObject == null && mouseItemData.AssignedInventorySlot.ItemObject != null)
        {
            clickedUISlot.AssignedInventorySlot.AssignItem(mouseItemData.AssignedInventorySlot);
            clickedUISlot.UpdateUISlot();
            mouseItemData.ClearSlot();
            return;
        }
        //インベントリが何か入っていて-マウスが何かアイテムを持っていたら
        bool isSameItem = clickedUISlot.AssignedInventorySlot.ItemObject == mouseItemData.AssignedInventorySlot.ItemObject;
        Debug.Log($"isSameItem {isSameItem}");
        if (clickedUISlot.AssignedInventorySlot.ItemObject != null && mouseItemData.AssignedInventorySlot.ItemObject != null)
        {
            //クリックしたインベントリのアイテムとマウスのアイテムが同じ&追加可能ならば
            if (isSameItem && clickedUISlot.AssignedInventorySlot.RoomLeftInStack(mouseItemData.AssignedInventorySlot.Amountsize))
            {
                clickedUISlot.AssignedInventorySlot.AssignItem(mouseItemData.AssignedInventorySlot);
                clickedUISlot.UpdateUISlot();

                mouseItemData.ClearSlot();
            }
            else if (isSameItem && !clickedUISlot.AssignedInventorySlot.RoomLeftInStack(mouseItemData.AssignedInventorySlot.Amountsize, out int leftInStack))
            {
                //追加して余りなし
                if (leftInStack < 1) SwapSlot(clickedUISlot);
                //追加して余りあり
                else
                {
                    //インベントリへ追加
                    int remainingOnMouse = mouseItemData.AssignedInventorySlot.Amountsize - leftInStack;
                    clickedUISlot.AssignedInventorySlot.AddToStack(leftInStack);
                    clickedUISlot.UpdateUISlot();
                    //余りはマウスに残す
                    var newItem = new ItemSystem(mouseItemData.AssignedInventorySlot.ItemObject, remainingOnMouse);
                    mouseItemData.ClearSlot();
                    mouseItemData.UpdateMouseSlot(newItem);
                }
            }//クリックしたインベントリのアイテムとマウスのアイテムが違う
            else// if (!isSameItem)
            {
                SwapSlot(clickedUISlot);
            }
        }
    }
    //マウスとインベントリのスワップ
    private void SwapSlot(InventorySlotUI clickedUISlot)
    {
        var cloneSlot = new ItemSystem(mouseItemData.AssignedInventorySlot.ItemObject, mouseItemData.AssignedInventorySlot.Amountsize);
        mouseItemData.ClearSlot();

        mouseItemData.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
        clickedUISlot.ClearSlot();
        clickedUISlot.AssignedInventorySlot.AssignItem(cloneSlot);
        clickedUISlot.UpdateUISlot();
    }

}
