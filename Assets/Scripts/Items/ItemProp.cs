using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Itempropety
{
    public class ItemProp
    {
        //=====アイテムのプロパティ=====
        private int item;
        /*public ItemProp(int item)
        {
            this.item = item;
        }*/
        public int Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
                if (item < 0)
                {
                    item = 0;
                }
            }
        }
    }
}