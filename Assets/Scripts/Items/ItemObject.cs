using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Pants,
    Shorts
}
[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]
public  class ItemObject : ScriptableObject
{
    //=====アイテムの基本パラメーター=====
    //アイテムのID
    public int ItemID;
    //アイテムのPrefab
    public GameObject prefab;
    //
    public ItemType type;
    //アイコンサムネ
    public Sprite Icon;
    //最大積載量
    public int MaxStackSize;
    [TextArea(15, 20)]
    public string Description;
}
