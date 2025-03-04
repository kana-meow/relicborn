using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemPickup : MonoBehaviour {
    [SerializeField] private float pickupRange = 2f;
    [SerializeField] private LayerMask relicLayer;

    [SerializeField] private Transform itemPickupUI;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;

    private Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;
    }

    private void Update() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRange, relicLayer);
        if (colliders.Length == 0) {
            itemPickupUI.gameObject.SetActive(false);
            return;
        }

        float smallestDistance = float.MaxValue;

        foreach (Collider col in colliders) {
            if (col.gameObject.TryGetComponent<RelicItem>(out RelicItem relic)) {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance < smallestDistance) {
                    smallestDistance = distance;
                    itemPickupUI.gameObject.SetActive(true);
                    itemPickupUI.position = mainCamera.WorldToScreenPoint(col.transform.position);
                    SetItemPickupUI(relic);
                }
            }
        }
    }

    private void SetItemPickupUI(RelicItem relic) {
        itemIcon.sprite = relic.icon;
        itemName.text = relic.itemName;
        itemDescription.text = relic.itemDescription;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}