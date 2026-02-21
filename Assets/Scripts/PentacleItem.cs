using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PentacleItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField]
    private Image image;

    [SerializeField]
    private TMP_Text itemNameText;

    private Transform parentAfterDrag;
    private Canvas canvas;

    private CollectibleItem itemData;

    private Vector3 _originalPosition;
    private bool _wasDragged;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _wasDragged = true;

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
        AudioManager.Instance.PlayUIDrop();

        transform.SetParent(parentAfterDrag);
        transform.localPosition = Vector3.zero;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        //AudioManager.Instance.PlayUIClick();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlayUIHover();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.Instance.PlayUIClick();

        _originalPosition = transform.position;
        _wasDragged = false;

        transform.position = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_wasDragged)
        {
            transform.position = _originalPosition;
        }
    }
}
