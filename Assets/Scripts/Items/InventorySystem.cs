using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{
    //=====変数の宣言=====
    //ItemObjectのリスト
    [SerializeField] private List<ItemSystem> itemSystems;
    //=====プロパティ=====
    //ItemObject
    public List<ItemSystem> ItemSystems => itemSystems;
    //インベントリの積載量
    public int InventorySystemSize => itemSystems.Count;
    //インベントリが変わったら
    public UnityAction<ItemSystem> OnInventorySystemSlotChanged;
    //=====が=====
    public InventorySystem(int size)
    {
        itemSystems = new List<ItemSystem>(size);
        for (int i = 0; i < size; i++)
        {
            itemSystems.Add(new ItemSystem());
        }
    }
    //=====インベントリの追加=====
    public bool AddToInventorySystem(ItemObject itemToAdd, int amountToAdd)
    {
        //もしitemToAddのアイテムをすでに持っていたら
        if (ContainsItem(itemToAdd, out List<ItemSystem> invSlot))
        {   
            foreach (var slot in invSlot)
            {
                //アイテムの最大積載量までに空きがあるか
                if (slot.RoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySystemSlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }
        //もしインベントリに空きがあったら
        if (HasFreeSlot(out ItemSystem freeSlot))
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySystemSlotChanged?.Invoke(freeSlot);
            return true;
        }
        return false;
    }
    //=====インベントリの削除=====
    public bool RemoveToInventorySystem(int choseSlot, int amountToRemove)
    {
        //選択したスロットにアイテムがあるかどうかの判定
        //private bool isItemExist = ItemSystems[choseSlot] == null ? false : true;
        if (ItemSystems[choseSlot] == null ? false : true)
        {
            ItemSystem bf = ItemSystems[choseSlot];
            //ItemObject item = bf.itemObject;
            bf.RemoveToStack(amountToRemove);
        }
        return false;
    }
    public bool ContainsItem(ItemObject itemToAdd, out List<ItemSystem> invSlot)
    {
        //where->フィルターをかける
        //ItemDataがitemToAddと等しかったらリストに追加
        invSlot = ItemSystems.Where(i => i.ItemObject == itemToAdd).ToList();
        //リストの要素が0だったらアイテムがないのでfalse
        return invSlot.Count == null ? false : true;
    }
    public bool HasFreeSlot(out ItemSystem freeSlot)
    {
        freeSlot = ItemSystems.FirstOrDefault(i => i.ItemObject == null);
        return freeSlot == null ? false : true;
    }
}
