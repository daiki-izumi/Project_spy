using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace inventory
{
    [System.Serializable]
    public class InventoryHolder : MonoBehaviour
    {
        //=====�ϐ��̐錾=====
        //ItemObject
        [SerializeField] private int inventorySize;
        [SerializeField] protected InventorySystem primaryInventorySystem;
        public InventorySystem PrimaryInventorySystem => primaryInventorySystem;
        public static UnityAction<InventorySystem> OnInventorySystemRequested;
        protected virtual void Awake()
        {
            primaryInventorySystem = new InventorySystem(inventorySize);
        }

    }
}

