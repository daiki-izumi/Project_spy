using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inventory;
using UnityEngine.Events;

public class PlayerInventoryHolder : InventoryHolder
{
    [SerializeField] protected int secondaryInventorySize;
    [SerializeField] protected InventorySystem secondaryInventorySystem;

    public InventorySystem SecondaryInventorySystem => secondaryInventorySystem;
    public static UnityAction<InventorySystem> OnPlayerBackpackRequested;

    protected override void Awake()
    {
        base.Awake();

        secondaryInventorySystem = new InventorySystem(secondaryInventorySize);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) OnPlayerBackpackRequested?.Invoke(secondaryInventorySystem);
    }

    public bool AddToInventorySystem(ItemObject data, int amount)
    {
        if (primaryInventorySystem.AddToInventorySystem(data, amount))
        {
            return true;
        }
        else if (secondaryInventorySystem.AddToInventorySystem(data, amount))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
