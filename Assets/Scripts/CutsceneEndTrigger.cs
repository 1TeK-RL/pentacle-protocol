using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneEndTrigger : MonoBehaviour
{
    public static TaskCompletionSource<bool> CutsceneFinished;

    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    public void StopCutscene()
    {
        if (videoPlayer != null && videoPlayer.isPlaying)
            videoPlayer.Stop();

        CutsceneFinished?.TrySetResult(true);
    }
}
