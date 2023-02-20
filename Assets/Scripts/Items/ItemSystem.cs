using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSystem
{
    //=====�ϐ��̐錾=====
    //ItemObject
    [SerializeField] private ItemObject itemObject;
    //�������Ă��鐔
    [SerializeField] private int amountSize;
    //=====�v���p�e�B=====
    //ItemObject
    public ItemObject Itemobject => itemObject;
    //�������Ă��鐔
    public int Amountsize => amountSize;
    //=====��=====
    public ItemSystem(ItemObject source, int amount)
    {
        itemObject = source;
        amountSize = amount;
    }
    //=====�C���x���g������̏��=====
    public ItemSystem()
    {
        ClearItemSystem();
    }
    public void ClearItemSystem()
    {
        itemObject = null;
        amountSize = -1;
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
    public void AddToStack(int amount)
    {
        amountSize += amount;
    }
    //=====�A�C�e���̍폜=====
    public void RemoveToStack(int amount)
    {
        amountSize -= amount;
    }
}
