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

    public async Task PlayCutsceneAsync(string cutsceneScene, string nextScene)
    {
        if (!string.IsNullOrEmpty(currentGameplayScene))
        {
            await SceneManager.UnloadSceneAsync(currentGameplayScene).ToTask();
        }

        await SceneManager.LoadSceneAsync(cutsceneScene, LoadSceneMode.Additive).ToTask();

        TaskCompletionSource<bool> cutsceneFinished = new();
        CutsceneEndTrigger.CutsceneFinished = cutsceneFinished;
        await cutsceneFinished.Task;

        await SceneManager.UnloadSceneAsync(cutsceneScene).ToTask();

        await SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive).ToTask();
        currentGameplayScene = nextScene;
    }
}
