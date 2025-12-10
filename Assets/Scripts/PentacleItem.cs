using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PentacleItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField]
    private Image image;

    [SerializeField]
    private TMP_Text itemNameText;

    private Transform parentAfterDrag;
    private Canvas canvas;

    private CollectibleItem itemData;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    public void ChangeParent(Transform newParent)
    {
        parentAfterDrag = newParent;
    }

    public Transform GetParent()
    {
        return parentAfterDrag;
    }

    public void Initialize(CollectibleItem itemData)
    {
        this.itemData = itemData;
        image.sprite = itemData.itemImage;
        itemNameText.text = itemData.itemName;
    }

    public CollectibleItem GetItemData()
    {
        return itemData;
    }
}
