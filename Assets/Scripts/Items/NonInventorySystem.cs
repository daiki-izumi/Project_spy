using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using dropitemParas;

//[System.Serializable]
public class NonInventorySystem
{
    //=====変数の宣言=====
    //ItemSystemObjectのリスト
    [SerializeField] public ItemSystemObject itemSystemObject;
    //くじ引きの箱
    public List<int> Slot;
    //くじ引きの箱の大きさ
    public int SlotSize = 100;
    //ドロップするアイテムのパラメーター
    private DropItemParameter dropItemParameter;
    //=====プロパティ=====
    //ItemSystemObject
    public ItemSystemObject ItemSystemObject => itemSystemObject;
    [SerializeField] private int chosen;
    //=====が=====
    public NonInventorySystem(ItemSystemObject source)
    {
        itemSystemObject = source;
        Slot = new List<int>(SlotSize);
        dropItemParameter = new DropItemParameter();
        MakeSystem();
    }
    //対応表の作成
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
    //=====ドロップするアイテムを返す=====
    public ItemObject DropItem()
    {
        int slotnumber = RandomChooseItem();
        return itemSystemObject.itemsList[slotnumber];
    }
    //=====ドロップするアイテムの確率=====
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
            //レベル4のアイテム
            bf = 4;
        }
        else if (chosen < dropItemParameter.rarelevel3 && chosen > dropItemParameter.rarelevel4)
        {
            //レベル3のアイテム
            bf = 3;
        }
        else if (chosen < dropItemParameter.rarelevel2 && chosen > dropItemParameter.rarelevel3)
        {
            //レベル2のアイテム
            bf = 2;
        }
        else
        {
            //レベル1のアイテム
            bf = 1;
        }
        //レベル5のアイテム
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
