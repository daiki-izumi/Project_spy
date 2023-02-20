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
    [SerializeField] private List<ItemSystem> itemObjects;
    //=====プロパティ=====
    //ItemObject
    public List<ItemSystem> Itemobjects => itemObjects;
    //インベントリの積載量
    public int InventorySystemsize => Itemobjects.Count;
    //インベントリが変わったら
    public UnityAction<ItemSystem> OnInventorySystemSlotChanged;
    //=====が=====
    public InventorySystem(int size)
    {
        itemObjects = new List<ItemSystem>(size);
        for (int i = 0; i < size; i++)
        {
            itemObjects.Add(new ItemSystem());
        }
    }
    //=====インベントリの追加=====
    public bool AddToInventorySystem(ItemObject itemToAdd, int amountToAdd)
    {
        itemObjects[0] = new ItemSystem(itemToAdd, amountToAdd);
        return true;
    }
}
