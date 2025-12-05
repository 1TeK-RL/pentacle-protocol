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
    }

    private void OnEnable()
    {
        EventManager.Instance.OnPlayerMove += PlayAudioFootsteps;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnPlayerMove -= PlayAudioFootsteps;
    }

    void PlayAudioFootsteps(PlayerMoveEvent playerMoveEvent)
    {
        if (playerMoveEvent.playSound)
        {
            RuntimeManager.PlayOneShot("event:/Footsteps");
        }
    }
}
