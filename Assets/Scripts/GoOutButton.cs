using UnityEngine;
using UnityEngine.UI;

public class GoOutButton : MonoBehaviour
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
        await EventManager.Instance.SceneLoader.PlayCutsceneAsync("GoOut", "DeskScene");
    }
}
