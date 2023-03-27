using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopKeeper: MonoBehaviour, IInteractable
{
	[SerializeField] private ShopItemList _shopItemsHeld;
	[SerializeField] private ShopSystem _shopSystem;

	public UnityAction<IInteractable> OnInteractionComplete { get; set; }

	private void Awake()
    {
		_shopSystem = new ShopSystem(_shopItemsHeld.Items.Count);
        foreach (var item in _shopItemsHeld.Items)
        {
			_shopSystem.AddToShop(item.ItemObject, item.Amount);
        }
    }

	public void Interact(Interactor interactor, out bool interactSuccessful)
    {
		throw new System.NotImplementedException();
    }

	public void EndInteraction()
	{
		throw new System.NotImplementedException();
	}

}
