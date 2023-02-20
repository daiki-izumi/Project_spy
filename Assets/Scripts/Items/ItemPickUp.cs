using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    //=====�ϐ��̐錾=====
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
        var inventory = other.transform.GetComponent<InventoryHolder>();
        Debug.Log($"�A�C�e���ɐG�ꂽ��, {inventory}");
        if (!inventory) return;
        if (inventory.InventorySystem.AddToInventorySystem(itemObject, 1))
        {
            Destroy(this.gameObject);
        }
    }
}
