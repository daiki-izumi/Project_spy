using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using dropitemParas;

//[System.Serializable]
public class NonInventorySystem
{
    //=====�ϐ��̐錾=====
    //ItemSystemObject�̃��X�g
    [SerializeField] public ItemSystemObject itemSystemObject;
    //���������̔�
    public List<int> Slot;
    //���������̔��̑傫��
    public int SlotSize = 100;
    //�h���b�v����A�C�e���̃p�����[�^�[
    private DropItemParameter dropItemParameter;
    //=====�v���p�e�B=====
    //ItemSystemObject
    public ItemSystemObject ItemSystemObject => itemSystemObject;
    [SerializeField] private int chosen;
    //=====��=====
    public NonInventorySystem(ItemSystemObject source)
    {
        itemSystemObject = source;
        Slot = new List<int>(SlotSize);
        dropItemParameter = new DropItemParameter();
        MakeSystem();
    }
    //�Ή��\�̍쐬
    public void MakeSystem()
    {
        foreach (var rare in itemSystemObject.itemsList)
        {
            Slot.Add(rare.RareValue);
            /*
            if (!Slot.Contains(rare.RareValue))
            {
                Slot.Add(rare.RareValue);
            }*/
        }
        Slot.Sort();

    }
    //=====�h���b�v����A�C�e����Ԃ�=====
    public ItemObject DropItem()
    {
        int slotnumber = RandomChooseItem();
        return itemSystemObject.itemsList[slotnumber];
    }
    //=====�h���b�v����A�C�e���̊m��=====
    public int RandomChooseItem()
    {
        chosen = Random.Range(0, SlotSize);
        int bf;
        if (chosen < dropItemParameter.rarelevel5)
        {
            bf = 5;
        }
        else if (chosen < dropItemParameter.rarelevel4 && chosen > dropItemParameter.rarelevel5)
        {
            //���x��4�̃A�C�e��
            bf = 4;
        }
        else if (chosen < dropItemParameter.rarelevel3 && chosen > dropItemParameter.rarelevel4)
        {
            //���x��3�̃A�C�e��
            bf = 3;
        }
        else if (chosen < dropItemParameter.rarelevel2 && chosen > dropItemParameter.rarelevel3)
        {
            //���x��2�̃A�C�e��
            bf = 2;
        }
        else
        {
            //���x��1�̃A�C�e��
            bf = 1;
        }
        //���x��5�̃A�C�e��
        List<int> invSlot = Slot.Where(i => i == bf).ToList();
        if (invSlot.Count == null)
        {
            chosen = Random.Range(0, Slot.Count);
        }
        else
        {
            chosen = Random.Range(0, invSlot.Count);
        }
        return chosen;

    }

}
