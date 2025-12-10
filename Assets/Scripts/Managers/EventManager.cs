using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public SceneLoader SceneLoader { get; private set; }

    public event Action<PlayerMoveEvent> OnPlayerMove;

    public event Action OnUpdateScene;

    public event Action OnMouthDoorOpen;

    public event Action<AnimationFrames> OnChangeAnimationType;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void RegisterSceneLoader(SceneLoader sceneLoader)
    {
        SceneLoader = sceneLoader;
    }

    public void PlayerMove(Vector2 pos, Quaternion rot, bool playsound, ZoneTypes type)
    {
        var data = new PlayerMoveEvent(pos, rot,playsound, type);
        OnPlayerMove?.Invoke(data);
    }

    public void UpdateScene()
    {
        OnUpdateScene?.Invoke();
    }   

    public void OpenMouthDoor()
    {
        OnMouthDoorOpen?.Invoke();
    }

    public void ChangeAnimationFrames(AnimationFrames animationFrames)
    {
        OnChangeAnimationType?.Invoke(animationFrames);
    }
}
