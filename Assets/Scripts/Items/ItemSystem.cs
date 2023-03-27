using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSystem : ItemSlot
{
    /*
    //=====変数の宣言=====
    //ItemObject
    [SerializeField] private ItemObject itemObject;
    //今持っている数
    [SerializeField] private int amountSize;
    //=====プロパティ=====
    //ItemObject
    public ItemObject ItemObject => itemObject;
    //今持っている数
    public int Amountsize => amountSize;*/
    //=====が=====
    public ItemSystem(ItemObject source, int amount)
    {
        itemObject = source;
        amountSize = amount;
    }
    public ItemSystem(ItemObject source)
    {
        itemObject = source;
        amountSize = 999999999;
    }
    //=====インベントリが空の状態=====
    public ItemSystem()
    {
        ClearItemSystem();
    }
    /*public void ClearItemSystem()
    {
        itemObject = null;
        amountSize = -1;
    }*/
    //=====アイテムの直接操作=====
    public void UpdateInventorySlot(ItemObject data, int amount)
    {
        itemObject = data;
        amountSize = amount;
    }
    //=====アイテムの追加=====
    public bool RoomLeftInStack(int amountToAdd, out int amountRoom)
    {
        amountRoom = itemObject.MaxStackSize - amountSize;
        return RoomLeftInStack(amountToAdd);
    }
    //アイテムが最大積載量に達しているか
    public bool RoomLeftInStack(int amountToAdd)
    {
        if (amountSize + amountToAdd <= itemObject.MaxStackSize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /*
    //アイテムの追加
    public void AddToStack(int amount)
    {
        amountSize += amount;
    }
    //=====アイテムの削除=====
    public void RemoveToStack(int amount)
    {
        amountSize -= amount;
        if (amountSize <= 0)
        {
            ClearItemSystem();
        }
    }*/
    //=====アイテムの代入=====
    /*
    public void AssignItem(ItemSystem invSlot)
    {
        if (itemObject == invSlot.ItemObject) AddToStack(invSlot.amountSize);
        else { 
            itemObject = invSlot.itemObject;
            amountSize = 0; 
            AddToStack(invSlot.amountSize); 
        }
    }*/

}
