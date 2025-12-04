using UnityEngine;

public class OnColliderClicked : MonoBehaviour
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
        InteractionEvents.movePlayerTo?.Invoke(nextRoomPOV.transform.position, nextRoomPOV.transform.rotation);
    }
}
