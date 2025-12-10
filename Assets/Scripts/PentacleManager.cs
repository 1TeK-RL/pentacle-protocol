using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PentacleManager : MonoBehaviour
{
    [Header("Pentacle Slots")]
    [SerializeField] private List<ItemSpot> PentacleSlots;

    [Header("Inventory UI")]
    [SerializeField] private GridLayoutGroup inventoryGrid;
    [SerializeField] private GameObject pentaclePrefab; // Prefab to spawn PentacleItems

    [SerializeField] private float waitTime = 6f; // seconds

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        RefreshInventory();
    }

    /// <summary>
    /// Refresh the inventory UI by spawning PentacleItem prefabs for each collected item
    /// </summary>
    public void RefreshInventory()
    {
        Debug.Log("Refreshing Pentacle Inventory UI...");

        gameManager = GameManager.Instance;
        gameManager.RemovePentacledFromAll();

        List<CollectibleItem> deskInventory = gameManager.GetAcquiredItems();

        int slotCount = inventoryGrid.transform.childCount;
        int itemCount = deskInventory.Count;

        for (int i = 0; i < slotCount; i++)
        {
            Transform slot = inventoryGrid.transform.GetChild(i);

            // Clear previous item if it exists
            if (slot.childCount > 0)
            {
                Destroy(slot.GetChild(0).gameObject);
            }

            // Spawn item if available
            if (i < itemCount)
            {
                GameObject obj = Instantiate(pentaclePrefab, slot);
                PentacleItem instance = obj.GetComponent<PentacleItem>();
                instance.Initialize(deskInventory[i]); // Set image and data
            }
        }
    }

    /// <summary>
    /// Start the pentagram protocol (lighting sequence)
    /// </summary>
    public void StartPentagramProtocol()
    {
        StartCoroutine(PentagramProtocolRoutine());
    }

    private IEnumerator PentagramProtocolRoutine()
    {
        gameManager = GameManager.Instance;

        // 1. Light the fires in sequence
        yield return StartCoroutine(PentagramRoutine());

        // 2. Load the next scene asynchronously
        yield return StartCoroutine(LoadNextSceneCoroutine());
    }

    private IEnumerator PentagramRoutine()
    {
        float interval = waitTime / PentacleSlots.Count;

        foreach (var slot in PentacleSlots)
        {
            PentacleItem pentacleItem = slot.GetPentacleItem();
            if (pentacleItem != null)
            {
                gameManager.ChangeItemState(pentacleItem.GetItemData(), GameManager.InventoryState.Pentacled);
                slot.LitOnFire();

                AudioManager.Instance.PlayUIBurn();

                Debug.Log($"Lit {pentacleItem.GetItemData().itemName} on fire!");

                yield return new WaitForSeconds(interval);
            }
        }

        // Small delay for teleport animation
        yield return new WaitForSeconds(0.5f);

        // Stop all fires
        foreach (var slot in PentacleSlots)
        {
            slot.StopFire();
        }
    }

    private IEnumerator LoadNextSceneCoroutine()
    {
        var loadTask = EventManager.Instance.SceneLoader.PlayCutsceneAsync("GoIn", "MovementsScene");

        while (!loadTask.IsCompleted)
            yield return null;

        if (loadTask.IsFaulted)
            Debug.LogError(loadTask.Exception);
    }
}