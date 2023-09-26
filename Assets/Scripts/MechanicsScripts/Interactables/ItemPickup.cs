public class ItemPickup : Interactable
{

    public InventoryItemData item;   // Item to put in the inventory if picked up

    // When the player interacts with the item
    public override void OnInteract()
    {
        base.OnInteract();

        PickUp();
    }

    // Pick up the item
    void PickUp()
    {
        InventorySystem.Instance.Add(item);   // Add to inventory

        Destroy(gameObject);    // Destroy item from scene
    }
}