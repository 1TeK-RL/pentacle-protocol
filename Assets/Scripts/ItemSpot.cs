using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSpot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private AnimatedSprite fire;

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

    public PentacleItem GetPentacleItem()
    {
        if (transform.childCount == 0)
            return null;

        return transform.GetChild(0).GetComponent<PentacleItem>();
    }

    public void LitOnFire()
    {
        if (fire != null)
        {
            fire.gameObject.SetActive(true);
            fire.PlayAnimation();
        }
        else
        {
            Debug.Log("No fire on this spot");
        }
    }

    public void StopFire()
    {
        if (fire != null)
        {
            fire.PauseAnimation();
            fire.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("No fire on this spot");
        }
    }
}
