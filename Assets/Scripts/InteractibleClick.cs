using System;
using UnityEngine;

public class InteractibleClick : MonoBehaviour
{
    [SerializeField] private string povName;

    [SerializeField] private GameObject nextRoomPOV;

    private Collider2D interactionCollider;

    [SerializeField]
    private bool isOpened = false;

    private void Awake()
    {
        interactionCollider = GetComponent<Collider2D>();
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

            EventManager.Instance.PlayerMove(nextRoomPOV.transform.position, nextRoomPOV.transform.rotation, true, nextRoomPOV.GetComponent<ZoneType>().Type);
        }
    }

    private void OnMouseEnter()
    {
        if (!isOpened)
        {
            CursorManager.Instance.SetCursorType(CursorType.Cross);
        }
        else
        {
            CursorManager.Instance.SetCursorType(CursorType.Forward);
        }
    }

    public void OnMouseExit()
    {
        CursorManager.Instance.SetCursorType(CursorType.Default);
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
