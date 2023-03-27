using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopSystem
{
    [SerializeField] private List<ShopSlot> _shopInventory;

    //一旦アイテムのサイズだけ
    public ShopSystem(int size)
    {
        SetShopSize(size);
    }
    //要求されたサイズのスロットを用意
    private void SetShopSize(int size)
    {
        _shopInventory = new List<ShopSlot>(size);
        for (int i = 0; i < size; i++)
        {
            _shopInventory.Add(new ShopSlot());
        }
    }
    //ショップへ追加(初期化)
    public void AddToShop(ItemObject data, int amount)
    {
        if (ContainsItem(data, out ShopSlot shopSlot))
        {
            shopSlot.AddToStack(amount);
        }
        var freeSlot = GetFreeSlot();
        freeSlot.AssignItem(data, amount);
    }

    public ShopSlot GetFreeSlot()
    {
        var freeSlot = _shopInventory.FirstOrDefault(i => i.ItemObject == null);

        if (freeSlot == null)
        {
            freeSlot = new ShopSlot();
            _shopInventory.Add(freeSlot);
        }

        return freeSlot;
    }

    public bool ContainsItem(ItemObject itemToAdd, out ShopSlot shopSlot)
    {
        //where->フィルターをかける
        //ItemDataがitemToAddと等しかったらリストに追加
        shopSlot = _shopInventory.Find(i => i.ItemObject == itemToAdd);
        //リストの要素が0だったらアイテムがないのでfalse
        return shopSlot != null;
    }
}
