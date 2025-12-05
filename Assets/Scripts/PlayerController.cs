using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.Instance.OnPlayerMove += MoveTo;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnPlayerMove -= MoveTo;
    }

    void MoveTo(PlayerMoveEvent playerMoveEvent)
    {
        transform.position = playerMoveEvent.position;
        transform.rotation = playerMoveEvent.rotation;

        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }
}
