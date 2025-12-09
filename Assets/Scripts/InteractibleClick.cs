using System;
using UnityEngine;

public class InteractibleClick : MonoBehaviour
{
    [SerializeField] private string povName;

    [SerializeField] private GameObject nextRoomPOV;

    Collider interactionCollider;

    [SerializeField]
    private bool isOpened = false;

    private void Start()
    {
        interactionCollider = GetComponent<Collider>();
        if (nextRoomPOV == null)
        {
            interactionCollider.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if (isOpened)
        {
            if (!string.IsNullOrEmpty(povName))
            {
                GameManager.Instance.SetWorldState(povName);
            }

            EventManager.Instance.PlayerMove(nextRoomPOV.transform.position, nextRoomPOV.transform.rotation);
        }
    }

    public void ChangeWorldState()
    {
        if (!string.IsNullOrEmpty(povName))
        {
            GameManager.Instance.SetWorldState(povName);
        }
    }

    public void OpenDoor()
    {
        isOpened = true;
    }

    public void CloseDoor()
    {
        isOpened = false;
    }
}
