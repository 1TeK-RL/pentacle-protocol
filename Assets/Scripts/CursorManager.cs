using UnityEngine;

public enum CursorType
{
    Default,
    Hover,
    Arrow
}

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance { get; private set; }

    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D hoverCursor;
    [SerializeField] private Texture2D arrowCursor;

    [SerializeField] private Vector2 cursorPosition = Vector2.zero;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Cursor.SetCursor(defaultCursor, cursorPosition, CursorMode.Auto);
    }

    public void SetCursorType(CursorType cursorType)
    {
        switch (cursorType)
        {
            case CursorType.Default:
                Cursor.SetCursor(defaultCursor, cursorPosition, CursorMode.Auto);
                break;
            case CursorType.Hover:
                Cursor.SetCursor(hoverCursor, cursorPosition, CursorMode.Auto);
                break;
            case CursorType.Arrow:
                Cursor.SetCursor(arrowCursor, cursorPosition, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(defaultCursor, cursorPosition, CursorMode.Auto);
                break;
        }
    }
}
