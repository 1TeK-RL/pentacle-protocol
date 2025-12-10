using UnityEngine;

public struct PlayerMoveEvent
{
    public Vector2 position;
    public Quaternion rotation;
    public bool playSound;
    public ZoneTypes type;

    public PlayerMoveEvent(Vector2 position, Quaternion rotation, bool playsound, ZoneTypes type)
    {
        this.position = position;
        this.rotation = rotation;
        this.playSound = playsound;
        this.type = type;
    }
}
