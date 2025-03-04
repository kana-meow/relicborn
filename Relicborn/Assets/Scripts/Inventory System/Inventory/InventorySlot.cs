using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler {
    public GameObject content;
    public ItemType acceptedItemType;

    private void OnEnable() {
        content = transform.Find("Content").gameObject;
    }

    public void OnDrop(PointerEventData eventData) {
        Transform parent = transform.Find("Content");

        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (parent.childCount == 0 && acceptedItemType == inventoryItem.item.ItemType) {
            inventoryItem.Parent = parent;
        }
    }
}