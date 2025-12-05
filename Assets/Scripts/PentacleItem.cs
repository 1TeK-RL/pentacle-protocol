using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PentacleItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform parentAfterDrag;

    [SerializeField]
    private Image image;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);   // Keep it inside the canvas
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
}
