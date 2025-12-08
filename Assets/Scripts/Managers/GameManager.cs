using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum itemState
{
    NotInInventory,
    Pentacled,
    NotPentacled
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private PentacleItem coinItem;

    [SerializeField]
    private DialogAsset charonDialog1;

    [SerializeField]
    private DialogAsset charonDialog2;

    private List<PentacleItem> deskInventory;
    private List<PentacleItem> infernetInventory;

    private Dictionary<PentacleItem, itemState> itemDictionary;

    [SerializeField] private Dictionary<string, bool> worldStates = new();

    private DialogManager dialogManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        dialogManager = DialogManager.Instance;

        deskInventory = new List<PentacleItem>();
        infernetInventory = new List<PentacleItem>();
    }

    public void DebugThis(string message)
    {
        Debug.Log(message);
    }

    public void AddItem(string itemName)
    {
        if (itemName == "coin")
        {
            deskInventory.Add(coinItem);
        }
    }

    public bool HasItem(PentacleItem item)
    {
        if (infernetInventory.Contains(item))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void TalkToCharon()
    {
        if (HasItem(coinItem)) {
            dialogManager.StartDialog(charonDialog2);
        }
        else
        {
            dialogManager.StartDialog(charonDialog1);
        }

    }

    public void SetWorldState(string povName)
    {
        if (worldStates.ContainsKey(povName))
        {
            worldStates[povName] = true;

            EventManager.Instance.UpdateScene();
        }
    }

    public bool GetWorldState(string povName)
    {
        if (worldStates.ContainsKey(povName))
        {
            return worldStates[povName];
        }
        else
        {
            worldStates.Add(povName, false);
            return false;
        }
    }
}