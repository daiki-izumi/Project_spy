using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopKeeper: MonoBehavior, IInteractable
{
	[SerializeField] private ShopItemList _shopItemsHeld;
	[SerializeField] private ShopSystem _shopSystem;

	private void Awake()
    {
		_shopSystem = new ShopSystem(_shopItemsHeld.Items.Count);
        foreach (var item in _shopItemsHeld.Items)
        {
			_shopSystem.AddToShop(item.ItemObject, item.Amount);
        }
    }

	public UnityAction<IInteractable> OnInteractionComplete { get; set; }

	public void Interact(Interactor interactor, out bool interactSuccessful)
    {
		throw new System.NotImplementedException();
    }

	public void EndInteraction(Interactor interactor, out bool interactSuccessful)
	{
		throw new System.NotImplementedException();
	}

}
