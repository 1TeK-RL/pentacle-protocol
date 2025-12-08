using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private List<ItemSpot> PentacleSlots;

    [SerializeField]
    private GridLayoutGroup inventoryGrid;

    [SerializeField]
    private PentacleItem coinItem;

    [SerializeField]
    private DialogAsset charonDialog1;

    [SerializeField]
    private DialogAsset charonDialog2;

    private List<PentacleItem> deskInventory;
    private List<PentacleItem> infernetInventory;

    private DialogManager dialogManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

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

    public void RefreshInventory()
    {
        int slotCount = inventoryGrid.transform.childCount;
        int itemCount = deskInventory.Count;

        for (int i = 0; i < slotCount; i++)
        {
            Transform slot = i < slotCount ? inventoryGrid.transform.GetChild(i) : null;

            // clear slot if it exists
            if (slot != null && slot.childCount > 0)
                Destroy(slot.GetChild(0).gameObject);

            // spawn item if available
            if (i < itemCount)
                Instantiate(deskInventory[i], slot);
        }
    }

    public void StartPentagramProtocol()
    {
        StartCoroutine(PentagramRoutine());
    }

    private IEnumerator PentagramRoutine()
    {
        foreach (var slot in PentacleSlots)
        {
            // if it has an item
            if (slot.transform.childCount >0 )
            {
                // add the current item placed in the slot to the infernet inventory
                infernetInventory.Add(slot.GetPentacleItem());

                slot.LitOnFire();

                Debug.Log("FIREEEE");

                // wait one second before doing the next one
                yield return new WaitForSeconds(2f);

            }
        }

        // send player to other scene here



        foreach (var slot in PentacleSlots)
        {
            // if it has an item
            if (slot.transform.childCount > 0)
            {

                // stop animation and hide fires
                slot.StopFire();

            }
        }
        
    }

}