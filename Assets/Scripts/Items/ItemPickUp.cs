using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inventory;

public class ItemPickUp : MonoBehaviour
{
    //=====変数の宣言=====
    private int PickUpRadius = 2;
    private SphereCollider myCollider;
    public ItemObject itemObject;
    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = PickUpRadius;
    }
    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<PlayerInventoryHolder>();
        Debug.Log($"アイテムに触れたよ, {inventory}");
        if (!inventory) return;
        if (inventory.AddToInventorySystem(itemObject, 1))
        {
            Destroy(this.gameObject);
        }
    }
}
