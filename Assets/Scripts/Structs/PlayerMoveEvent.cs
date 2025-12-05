using UnityEngine;

public struct PlayerMoveEvent
{
    public Vector2 position;
    public Quaternion rotation;
    public bool playSound;

    public PlayerMoveEvent(Vector2 position, Quaternion rotation, bool playSound)
    {
        this.position = position;
        this.rotation = rotation;
        this.playSound = playSound;
    }
}
