using FMOD.Studio;
using FMODUnity;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private EventReference charonVoiceEvent;
    [SerializeField] private EventReference nurseVoiceEvent;
    [SerializeField] private EventReference guardianVoiceEvent;
    [SerializeField] private EventReference heartbeatVoiceEvent;

    [SerializeField] private EventReference hospitalAmbiance;
    [SerializeField] private EventReference carAmbiance;
    [SerializeField] private EventReference menuAmbiance;

    private EventInstance instanceDialog;
    private EventInstance instanceAmbiance;

    [SerializeField] private float _pauseDelay = 2f;

    private Coroutine _pauseRoutine;

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

    public void PlayUIHover()
    {
        RuntimeManager.PlayOneShot("event:/UI_hover");
    }

    public void PlayUIClick()
    {
        RuntimeManager.PlayOneShot("event:/UI_click");
    }

    public void PlayUIDrop()
    {
        RuntimeManager.PlayOneShot("event:/UI_drop");
    }

    public void PlayUIBurn()
    {
        RuntimeManager.PlayOneShot("event:/UI_burning");
    }

    public void PlaySpoonEyeSound()
    {
        RuntimeManager.PlayOneShot("event:/Eye_ripping_off");
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

    public void SetHeartbeatVoice()
    {
        instanceDialog = RuntimeManager.CreateInstance(heartbeatVoiceEvent);
    }



    /// <summary>
    /// Resume or start dialog voice
    /// </summary>
    public void StartDialogVoice()
    {
        if (!instanceDialog.isValid())
            return;

        // Cancel pending pause
        CancelDelayedPause();

        instanceDialog.getPaused(out bool isPaused);

        if (isPaused)
        {
            instanceDialog.setPaused(false);
            return;
        }

        instanceDialog.getPlaybackState(out PLAYBACK_STATE state);

        if (state == PLAYBACK_STATE.STOPPED)
        {
            instanceDialog.start();
        }
    }

    /// <summary>
    /// Request a delayed pause
    /// </summary>
    public void StopDialogVoice()
    {
        if (!instanceDialog.isValid())
            return;

        if (_pauseRoutine != null)
            return; // already waiting

        _pauseRoutine = StartCoroutine(PauseDelayed());
    }

    /// <summary>
    /// Pause after delay
    /// </summary>
    private IEnumerator PauseDelayed()
    {
        yield return new WaitForSeconds(_pauseDelay);

        if (instanceDialog.isValid())
        {
            instanceDialog.getPaused(out bool isPaused);

            if (!isPaused)
                instanceDialog.setPaused(true);
        }

        _pauseRoutine = null;
    }

    /// <summary>
    /// Cancel any pending delayed pause
    /// </summary>
    private void CancelDelayedPause()
    {
        if (_pauseRoutine == null)
            return;

        StopCoroutine(_pauseRoutine);
        _pauseRoutine = null;
    }

    public void ReleaseDialogVoice() 
    { 
        if (instanceDialog.isValid()) 
        { 
            instanceDialog.release(); 
        } 
    }


    public void SetCarAmbiance()
    {
        instanceAmbiance = RuntimeManager.CreateInstance(carAmbiance);
    }

    public void SetHospitalAmbiance()
    {
        instanceAmbiance = RuntimeManager.CreateInstance(hospitalAmbiance);
    }

    public void SetMenuAmbiance()
    {
        instanceAmbiance = RuntimeManager.CreateInstance(menuAmbiance);
    }

    public void StartAmbiance()
    {
        if (instanceAmbiance.isValid())
        {
            instanceAmbiance.start();
        }
    }

    public void StopAmbiance()
    {
        if (instanceAmbiance.isValid())
        {
            instanceAmbiance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    public void ReleaseAmbiance()
    {
        if (instanceAmbiance.isValid())
        {
            instanceAmbiance.release();
        }
    }
}
