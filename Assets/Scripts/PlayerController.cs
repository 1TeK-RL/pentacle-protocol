using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnEnable()
    {
        InteractionEvents.movePlayerTo += MoveTo;
    }

    private void OnDisable()
    {
        InteractionEvents.movePlayerTo -= MoveTo;
    }

    void MoveTo(Vector2 newPos, Quaternion newRot)
    {
        transform.position = newPos;
        transform.rotation = newRot;

        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }
}
