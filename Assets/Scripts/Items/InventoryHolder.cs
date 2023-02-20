using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    //=====�ϐ��̐錾=====
    //ItemObject
    [SerializeField] private int inventorySize;
    [SerializeField] protected InventorySystem inventorySystem;
    public InventorySystem InventorySystem => inventorySystem;
    public static UnityAction<InventorySystem> OnInventorySystemRequested;
    private void Awake()
    {
        inventorySystem = new InventorySystem(inventorySize);
    }

}
