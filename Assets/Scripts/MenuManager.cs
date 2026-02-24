using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public void Start()
    {
        AudioManager.Instance.SetMenuAmbiance();
        AudioManager.Instance.StartAmbiance();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public async void StartGame()
    {
        AudioManager.Instance.StopAmbiance();
        AudioManager.Instance.ReleaseAmbiance();

        //close this scene
        await SceneManager.UnloadSceneAsync("MenuScene").ToTask();
        await EventManager.Instance.SceneLoader.PlayCutsceneAsync("Intro", "DeskScene");
    }

    public void PlayClickSound()
    {
        AudioManager.Instance.PlayUIClick();
    }

    public void PlayHoverSound()
    {
        AudioManager.Instance.PlayUIHover();
    }
}
