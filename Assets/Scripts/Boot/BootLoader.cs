using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootLoader : MonoBehaviour
{
    private async void Start()
    {
        await LoadCoreScenes();

        await EventManager.Instance.SceneLoader.PlayCutsceneAsync("Intro", "DeskScene");
    }

    private Task LoadCoreScenes()
    {
        return Task.WhenAll(
            SceneManager.LoadSceneAsync("Managers", LoadSceneMode.Additive).ToTask(),
            SceneManager.LoadSceneAsync("Loaders", LoadSceneMode.Additive).ToTask()
        );
    }
}

public static class AsyncOperationExtensions
{
    public static Task ToTask(this AsyncOperation operation)
    {
        var tcs = new TaskCompletionSource<bool>();
        operation.completed += _ => tcs.SetResult(true);
        return tcs.Task;
    }
}
