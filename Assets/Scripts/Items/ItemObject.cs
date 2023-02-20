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
    //=====�A�C�e���̊�{�p�����[�^�[=====
    //�A�C�e����ID
    public int ItemID;
    //�A�C�e����Prefab
    public GameObject prefab;
    //
    public ItemType type;
    //�A�C�R���T���l
    public Sprite Icon;
    //�ő�ύڗ�
    public int MaxStackSize;
    [TextArea(15, 20)]
    public string Description;
}