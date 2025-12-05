using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSpot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        PentacleItem pentacleItem = droppedObject.GetComponent<PentacleItem>();
        if (transform.childCount == 0) // if the spot is empty
        {
            Debug.Log("Dropped on empty spot");
            pentacleItem.ChangeParent(this.transform);
        }
        else // if the spot is occupied, swap the items
        {
            GameObject currentSpot = transform.GetChild(0).gameObject;
            PentacleItem currentPentacleItem = currentSpot.GetComponent<PentacleItem>();
            currentPentacleItem.transform.SetParent(pentacleItem.GetParent());
            pentacleItem.ChangeParent(this.transform);
        }

    }

}
