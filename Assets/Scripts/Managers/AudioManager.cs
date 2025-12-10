using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private EventReference charonVoiceEvent;
    [SerializeField] private EventReference nurseVoiceEvent;
    [SerializeField] private EventReference guardianVoiceEvent;

    private EventInstance instanceDialog;

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

    public void PlayAudioFootsteps(PlayerMoveEvent playerMoveEvent)
    {
        if (playerMoveEvent.playSound)
        {
            if (playerMoveEvent.type != ZoneTypes.MouthZone)
            {
                RuntimeManager.PlayOneShot("event:/Footsteps_basic");
                return;
            }
            else
            {
                RuntimeManager.PlayOneShot("event:/Footsteps_mouth");
            }
        }
    }

    public void PlayUIClick()
    {
        RuntimeManager.PlayOneShot("event:/UI_click");
    }

    public void SetCharonVoice()
    {
        instanceDialog = RuntimeManager.CreateInstance(charonVoiceEvent);
    }

    public void SetNurseVoice()
    {
        instanceDialog = RuntimeManager.CreateInstance(nurseVoiceEvent);
    }

    public void SetGuardianVoice()
    {
        instanceDialog = RuntimeManager.CreateInstance(guardianVoiceEvent);
    }

    public void StartDialogVoice()
    {
        if (instanceDialog.isValid())
        {
            instanceDialog.start();
        }
    }

    public void StopDialogVoice()
    {
        if (instanceDialog.isValid())
        {
            instanceDialog.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    public void ReleaseDialogVoice()
    {
        if (instanceDialog.isValid())
        {
            instanceDialog.release();
        }
    }

    public void StartCharonDialog()
    {
        Debug.Log("Starting Charon Dialog");
    }

    public void StopCharonDialog()
    {
        Debug.Log("Stopping Charon Dialog");
    }
}
