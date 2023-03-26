using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inventory;
using UnityEngine.Events;

public class ChestInventory : InventoryHolder, IInteractable
{
    public UnityAction<IInteractable> OnInteractionComplete { get; set; }
    public void Interact(Interactor interactor, out bool interactSuccessful)
    {
        OnInventorySystemRequested?.Invoke(primaryInventorySystem);
        interactSuccessful = true;
    }

    public void EndInteraction()
    {

    }
}
