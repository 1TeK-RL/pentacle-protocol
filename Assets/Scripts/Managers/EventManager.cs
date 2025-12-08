using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public SceneLoader SceneLoader { get; private set; }

    public event Action<PlayerMoveEvent> OnPlayerMove;

    public event Action OnUpdateScene;

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

    public void PlayerMove(Vector2 pos, Quaternion rot, bool playSound = true)
    {
        var data = new PlayerMoveEvent(pos, rot, playSound);
        OnPlayerMove?.Invoke(data);
    }

    public void UpdateScene()
    {
        OnUpdateScene?.Invoke();
    }
}
