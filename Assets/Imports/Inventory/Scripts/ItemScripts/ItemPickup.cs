using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickup : MonoBehaviour
{
    [SerializeField] private float pickupRange = 1f;
    [SerializeField] private InventoryItemData itemData;
    private SphereCollider pickupCollider;
    
    private void Awake()
    {
        pickupCollider = GetComponent<SphereCollider>();
        pickupCollider.isTrigger = true;
        pickupCollider.radius = pickupRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<PlayerInventoryHolder>();
        if(inventory != null)
        {
            if (inventory.AddToInventory(itemData, 1))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
