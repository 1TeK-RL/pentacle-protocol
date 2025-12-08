using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject arrow;

    private void Awake()
    {
        arrow.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowArrow();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideArrow();
    }

    public void ShowArrow()
    {
        arrow.SetActive(true);
    }

    public void HideArrow()
    {
        arrow.SetActive(false);
    }
}