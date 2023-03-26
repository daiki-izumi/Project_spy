using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/System Item")]
public class ItemSystemObject : ScriptableObject
{
    //=====アイテムの基本パラメーター=====
    //アイテムのID
    public int ItemID;
    //アイテムの
    public List<ItemObject> itemsList;
    //レア度
    public List<int> RareValueList;
    [TextArea(15, 20)]
    public string Description;
}
