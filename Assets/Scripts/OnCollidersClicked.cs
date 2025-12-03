using UnityEngine;

public class OnCollidersClicked : MonoBehaviour
{
    public GameObject nextRoomPOV;

    private void OnMouseDown()
    {
        InteractionEvents.movePlayerTo?.Invoke(nextRoomPOV.transform.position, nextRoomPOV.transform.rotation);
    }
}
