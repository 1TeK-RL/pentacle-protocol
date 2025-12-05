using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class OnButtonClicked : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    private async void OnClick()
    {
        await EventManager.Instance.SceneLoader.LoadSceneAsync("MovementsScene");
    }
}
