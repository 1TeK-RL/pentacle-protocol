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
        AudioManager.Instance.StopDialogVoice();
        AudioManager.Instance.ReleaseDialogVoice();
        AudioManager.Instance.StopAmbiance();
        AudioManager.Instance.ReleaseAmbiance();
        await EventManager.Instance.SceneLoader.PlayCutsceneAsync("GoOut", "DeskScene");
    }
}
