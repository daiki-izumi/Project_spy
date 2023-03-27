using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSystem : ItemSlot
{
    /*
    //=====�ϐ��̐錾=====
    //ItemObject
    [SerializeField] private ItemObject itemObject;
    //�������Ă��鐔
    [SerializeField] private int amountSize;
    //=====�v���p�e�B=====
    //ItemObject
    public ItemObject ItemObject => itemObject;
    //�������Ă��鐔
    public int Amountsize => amountSize;*/
    //=====��=====
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
    //=====�C���x���g������̏��=====
    public ItemSystem()
    {
        ClearItemSystem();
    }
    /*public void ClearItemSystem()
    {
        itemObject = null;
        amountSize = -1;
    }*/
    //=====�A�C�e���̒��ڑ���=====
    public void UpdateInventorySlot(ItemObject data, int amount)
    {
        itemObject = data;
        amountSize = amount;
    }
    //=====�A�C�e���̒ǉ�=====
    public bool RoomLeftInStack(int amountToAdd, out int amountRoom)
    {
        amountRoom = itemObject.MaxStackSize - amountSize;
        return RoomLeftInStack(amountToAdd);
    }
    //�A�C�e�����ő�ύڗʂɒB���Ă��邩
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
    //�A�C�e���̒ǉ�
    public void AddToStack(int amount)
    {
        amountSize += amount;
    }
    //=====�A�C�e���̍폜=====
    public void RemoveToStack(int amount)
    {
        amountSize -= amount;
        if (amountSize <= 0)
        {
            ClearItemSystem();
        }
    }*/
    //=====�A�C�e���̑��=====
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
