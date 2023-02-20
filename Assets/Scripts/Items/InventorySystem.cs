using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{
    //=====�ϐ��̐錾=====
    //ItemObject�̃��X�g
    [SerializeField] private List<ItemSystem> itemObjects;
    //=====�v���p�e�B=====
    //ItemObject
    public List<ItemSystem> Itemobjects => itemObjects;
    //�C���x���g���̐ύڗ�
    public int InventorySystemsize => Itemobjects.Count;
    //�C���x���g�����ς������
    public UnityAction<ItemSystem> OnInventorySystemSlotChanged;
    //=====��=====
    public InventorySystem(int size)
    {
        itemObjects = new List<ItemSystem>(size);
        for (int i = 0; i < size; i++)
        {
            itemObjects.Add(new ItemSystem());
        }
    }
    //=====�C���x���g���̒ǉ�=====
    public bool AddToInventorySystem(ItemObject itemToAdd, int amountToAdd)
    {
        itemObjects[0] = new ItemSystem(itemToAdd, amountToAdd);
        return true;
    }
}
