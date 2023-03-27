using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop System/Shop Item List")]
public class ShopItemList:ScriptableObject
{
	[SerializeField] private List<ShopInventoryItem> _items;

	public List<ShopInventoryItem>  Items => _items;
}

[System.Serializable]
public struct ShopInventoryItem
{
	public ItemObject ItemObject;
	public int Amount;
}
