using UnityEngine;

[System.Serializable]
public abstract class Item : ScriptableObject {
    public Sprite icon;
    public string itemName;
    public bool stackable = false;
    public abstract ItemType ItemType { get; }

    [TextArea]
    public string itemDescription;
}

public enum ItemType {
    Weapon,
    Relic
}