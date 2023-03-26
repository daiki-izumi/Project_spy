using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/System Item")]
public class ItemSystemObject : ScriptableObject
{
    //=====�A�C�e���̊�{�p�����[�^�[=====
    //�A�C�e����ID
    public int ItemID;
    //�A�C�e����
    public List<ItemObject> itemsList;
    //���A�x
    public List<int> RareValueList;
    [TextArea(15, 20)]
    public string Description;
}
