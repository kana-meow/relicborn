using UnityEngine;

public class Inventory : MonoBehaviour {
    public InventorySlot[] inventorySlots;

    public Item testItem;
    public GameObject inventoryItemPrefab;

    private void Start() {
        AddItem(testItem);
    }

    public void AddItem(Item item) {
        if (GetEmptySlot(item, out InventorySlot slot)) {
            InstantiateInventoryItem(item, slot);
        }
    }

    private void InstantiateInventoryItem(Item item, InventorySlot slot) {
        InventoryItem newItem = Instantiate(inventoryItemPrefab).GetComponent<InventoryItem>();
        newItem.InitializeItem(item);
        newItem.Parent = slot.content.transform;

        Debug.Log($"Instantiated new item at {newItem.Parent.parent.name}");
    }

    private bool GetEmptySlot(Item item, out InventorySlot freeSlot) {
        foreach (InventorySlot slot in inventorySlots) {
            InventoryItem itemInSlot = slot.content.GetComponentInChildren<InventoryItem>();

            if (itemInSlot == null && item.ItemType == slot.acceptedItemType) {
                freeSlot = slot;
                return true;
            }
        }
        Debug.Log($"No empty inventory slot found for {item.itemName}");

        freeSlot = null;
        return false;
    }
}