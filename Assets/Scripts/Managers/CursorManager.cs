using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance { get; private set; }

    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D forwardCursor;
    [SerializeField] private Texture2D rightCursor;
    [SerializeField] private Texture2D backwardCursor;
    [SerializeField] private Texture2D leftCursor;
    [SerializeField] private Texture2D dialogCursor;
    [SerializeField] private Texture2D InteractCursor;
    [SerializeField] private Texture2D CrossCursor;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetCursorType(CursorType cursorType)
    {
        switch (cursorType)
        {
            case CursorType.Default:
                Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
                break;
            case CursorType.Forward:
                Cursor.SetCursor(forwardCursor, Vector2.zero, CursorMode.Auto);
                break;
            case CursorType.Right:
                Cursor.SetCursor(rightCursor, Vector2.zero, CursorMode.Auto);
                break;
            case CursorType.Backward:
                Cursor.SetCursor(backwardCursor, Vector2.zero, CursorMode.Auto);
                break;
            case CursorType.Left:
                Cursor.SetCursor(leftCursor, Vector2.zero, CursorMode.Auto);
                break;
            case CursorType.Dialog:
                Cursor.SetCursor(dialogCursor, Vector2.zero, CursorMode.Auto);
                break;
            case CursorType.Interact:
                Cursor.SetCursor(InteractCursor, Vector2.zero, CursorMode.Auto);
                break;
            case CursorType.Cross:
                Cursor.SetCursor(CrossCursor, Vector2.zero, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
                break;
        }
    }
}
