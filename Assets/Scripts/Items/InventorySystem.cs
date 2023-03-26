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
    [SerializeField] private List<ItemSystem> itemSystems;
    //=====�v���p�e�B=====
    //ItemObject
    public List<ItemSystem> ItemSystems => itemSystems;
    //�C���x���g���̐ύڗ�
    public int InventorySystemSize => itemSystems.Count;
    //�C���x���g�����ς������
    public UnityAction<ItemSystem> OnInventorySystemSlotChanged;
    //=====��=====
    public InventorySystem(int size)
    {
        itemSystems = new List<ItemSystem>(size);
        for (int i = 0; i < size; i++)
        {
            itemSystems.Add(new ItemSystem());
        }
    }
    //=====�C���x���g���̒ǉ�=====
    public bool AddToInventorySystem(ItemObject itemToAdd, int amountToAdd)
    {
        //����itemToAdd�̃A�C�e�������łɎ����Ă�����
        if (ContainsItem(itemToAdd, out List<ItemSystem> invSlot))
        {   
            foreach (var slot in invSlot)
            {
                //�A�C�e���̍ő�ύڗʂ܂łɋ󂫂����邩
                if (slot.RoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySystemSlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }
        //�����C���x���g���ɋ󂫂���������
        if (HasFreeSlot(out ItemSystem freeSlot))
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySystemSlotChanged?.Invoke(freeSlot);
            return true;
        }
        return false;
    }
    //=====�C���x���g���̍폜=====
    public bool RemoveToInventorySystem(int choseSlot, int amountToRemove)
    {
        //�I�������X���b�g�ɃA�C�e�������邩�ǂ����̔���
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
        //where->�t�B���^�[��������
        //ItemData��itemToAdd�Ɠ����������烊�X�g�ɒǉ�
        invSlot = ItemSystems.Where(i => i.ItemObject == itemToAdd).ToList();
        //���X�g�̗v�f��0��������A�C�e�����Ȃ��̂�false
        return invSlot.Count == null ? false : true;
    }
    public bool HasFreeSlot(out ItemSystem freeSlot)
    {
        freeSlot = ItemSystems.FirstOrDefault(i => i.ItemObject == null);
        return freeSlot == null ? false : true;
    }
}
