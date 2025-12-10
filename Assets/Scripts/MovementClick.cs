using UnityEngine;

public class MovementClick : MonoBehaviour
{
    [SerializeField] private GameObject nextRoomPOV;

    private void Start()
    {
        if (nextRoomPOV == null)
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnMouseDown()
    {
        EventManager.Instance.PlayerMove(nextRoomPOV.transform.position, nextRoomPOV.transform.rotation, true, nextRoomPOV.GetComponent<ZoneType>().Type);
    }
}
