using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Collectible Items for debug")]
    [SerializeField] private CollectibleItem coinItem;
    [SerializeField] private CollectibleItem eyeItem;

    [Header("Dialog Assets")]
    [SerializeField] private DialogAsset charonDialog1;
    [SerializeField] private DialogAsset charonDialog2;

    private Dictionary<CollectibleItem, InventoryState> inventory;
    private DialogManager dialogManager;

    public enum InventoryState
    {
        Acquired,
        Pentacled
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        inventory = new Dictionary<CollectibleItem, InventoryState>();
        dialogManager = DialogManager.Instance;

        // Initialize inventory with starting items for debub
        AddItem(coinItem);
        AddItem(eyeItem);
    }

    public void DebugThis(string message)
    {
        Debug.Log(message);
    }

    public void AddItem(CollectibleItem item)
    {
        if (!inventory.ContainsKey(item))
            inventory.Add(item, InventoryState.Acquired);
    }

    public bool HasItem(CollectibleItem item)
    {
        return inventory.ContainsKey(item);
    }

    public void ChangeItemState(CollectibleItem item, InventoryState state)
    {
        if (HasItem(item))
            inventory[item] = state;
        else
            Debug.LogWarning($"Trying to change state of item '{item.name}' not in inventory.");
    }

    public void RemovePentacledFromAll()
    {
        foreach (var key in new List<CollectibleItem>(inventory.Keys))
            inventory[key] = InventoryState.Acquired;
    }

    public void TalkToCharon()
    {
        if (HasItem(coinItem))
            dialogManager.StartDialog(charonDialog2);
        else
            dialogManager.StartDialog(charonDialog1);
    }

    public List<CollectibleItem> GetAcquiredItems()
    {
        return new List<CollectibleItem>(inventory.Keys);
    }
}
