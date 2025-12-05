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

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        CutsceneFinished?.TrySetResult(true);
    }
}
