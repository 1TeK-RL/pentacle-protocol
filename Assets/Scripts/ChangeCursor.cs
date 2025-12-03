using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] private CursorType cursorType;

    public void OnMouseEnter()
    {
        CursorManager.Instance.SetCursorType(cursorType);
    }

    public void OnMouseExit()
    {
        CursorManager.Instance.SetCursorType(CursorType.Default);
    }
}
