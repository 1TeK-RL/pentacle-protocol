using UnityEngine;

public class CheckSpriteState : MonoBehaviour
{
    [SerializeField] private Sprite sprite_off;
    [SerializeField] private Sprite sprite_on;

    [SerializeField] private string povName;

    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        EventManager.Instance.OnUpdateScene += ChangeSprite;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnUpdateScene -= ChangeSprite;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ChangeSprite();
    }

    public void ChangeSprite()
    {
        if (GameManager.Instance.GetWorldState(povName))
        {
            spriteRenderer.sprite = sprite_on;
        }
        else
        {
            spriteRenderer.sprite = sprite_off;
        }
    }
}
