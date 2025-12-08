using UnityEngine;

[CreateAssetMenu(fileName = "NewCollectibleItem", menuName = "Inventory/Collectible Item")]
public class CollectibleItem : ScriptableObject
{
    [Header("Basic Info")]
    public string itemName;
    public Sprite itemImage;
    [TextArea] public string description;
}
