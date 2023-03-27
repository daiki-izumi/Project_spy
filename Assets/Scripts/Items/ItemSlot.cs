using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSlot : MonoBehaviour
{
    //=====変数の宣言=====
    //ItemObject
    [SerializeField] protected ItemObject itemObject;
    //今持っている数
    [SerializeField] protected int amountSize;
    //=====プロパティ=====
    //ItemObject
    public ItemObject ItemObject => itemObject;
    //今持っている数
    public int Amountsize => amountSize;


    public void ClearItemSystem()
    {
        itemObject = null;
        amountSize = -1;
    }
    public void AssignItem(ItemSystem invSlot)
    {
        if (itemObject == invSlot.ItemObject) AddToStack(invSlot.amountSize);
        else
        {
            itemObject = invSlot.itemObject;
            amountSize = 0;
            AddToStack(invSlot.amountSize);
        }
    }
    public void AssignItem(ItemObject data, int amount)
    {
        if (itemObject == data) AddToStack(amount);
        else
        {
            itemObject = data;
            amountSize = 0;
            AddToStack(amount);
        }
    }
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
    }
}
