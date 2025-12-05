using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        InteractionEvents.soundMovePlayerTo += LaunchAudioFootsteps;
    }

    private void OnDisable()
    {
        InteractionEvents.soundMovePlayerTo -= LaunchAudioFootsteps;
    }

    void LaunchAudioFootsteps()
    {
        RuntimeManager.PlayOneShot("event:/Footsteps");
    }
}
