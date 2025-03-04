using UnityEngine;

[CreateAssetMenu(fileName = "New Relic", menuName = "Scriptables/Items/Weapon")]
public class WeaponItem : Item {
    public override ItemType ItemType => ItemType.Weapon;
}