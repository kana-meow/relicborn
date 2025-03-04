using UnityEngine;

[CreateAssetMenu(fileName = "New Relic", menuName = "Scriptables/Items/Relic")]
public class RelicItem : Item {
    public override ItemType ItemType => ItemType.Relic;
}