using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string currentGameplayScene;

    private void Awake()
    {
        EventManager.Instance.RegisterSceneLoader(this);
    }

    public async Task LoadSceneAsync(string sceneName)
    {
        if (!string.IsNullOrEmpty(currentGameplayScene))
        {
            await SceneManager.UnloadSceneAsync(currentGameplayScene).ToTask();
        }

        await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).ToTask();
        currentGameplayScene = sceneName;
    }

    public async Task PlayCutsceneAsync(string cutsceneScene, string nextScene)
    {
        await SceneManager.LoadSceneAsync(cutsceneScene, LoadSceneMode.Additive).ToTask();

        TaskCompletionSource<bool> cutsceneFinished = new();
        CutsceneEndTrigger.CutsceneFinished = cutsceneFinished;
        await cutsceneFinished.Task;

        await SceneManager.UnloadSceneAsync(cutsceneScene).ToTask();
        await LoadSceneAsync(nextScene);
    }
}
