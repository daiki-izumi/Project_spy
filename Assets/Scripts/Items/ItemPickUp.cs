using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inventory;

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
        var inventory = other.transform.GetComponent<PlayerInventoryHolder>();
        Debug.Log($"ƒAƒCƒeƒ€‚ÉG‚ê‚½‚æ, {inventory}");
        if (!inventory) return;
        if (inventory.AddToInventorySystem(itemObject, 1))
        {
            Destroy(this.gameObject);
        }
    }
}
