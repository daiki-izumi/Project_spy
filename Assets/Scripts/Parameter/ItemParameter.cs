using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itempropety;
using System;

namespace Itemparas
{
    public class ItemParameter
    {
        //=====�A�C�e���̃p�����[�^�[=====
        public enum Items
        {
            Rock,
            Ruby,
            Diamond
        }
        Dictionary<Items, int> itemDictionary = new Dictionary<Items, int>();
        ItemProp item1 = new ItemProp() { Item=10};
        //item1.Item = 30;
        //item1.Item -= 20;
        //Debug.Log($"�A�C�e���̏���, {item1.Item}");        
    }
}
