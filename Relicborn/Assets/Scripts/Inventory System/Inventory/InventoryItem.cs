using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public Item item;
    private Image image;

    private Transform parent;

    public Transform Parent {
        get {
            return parent;
        }
        set {
            parent = value;
            transform.SetParent(value);
        }
    }

    private void OnEnable() {
        image = GetComponent<Image>();
    }

    public void InitializeItem(Item newItem) {
        item = newItem;
        image.sprite = item.icon;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        image.raycastTarget = false;
        // put object on top of everything
        parent = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        image.raycastTarget = true;
        transform.SetParent(parent);
    }
}