using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    //=====•Ï”‚ÌéŒ¾=====
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
        Debug.Log($"ƒAƒCƒeƒ€‚ÉG‚ê‚½‚æ, {inventory}");
        if (!inventory) return;
        if (inventory.InventorySystem.AddToInventorySystem(itemObject, 1))
        {
            Destroy(this.gameObject);
        }
    }
}
