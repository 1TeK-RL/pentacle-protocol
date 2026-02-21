using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public async void StartGame()
    {
        //close this scene
        await SceneManager.UnloadSceneAsync("MenuScene").ToTask();
        await EventManager.Instance.SceneLoader.PlayCutsceneAsync("Intro", "DeskScene");
    }
}
