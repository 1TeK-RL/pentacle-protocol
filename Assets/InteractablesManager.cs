using Unity.VisualScripting;
using UnityEngine;

public class InteractablesManager : MonoBehaviour
{
    [SerializeField]
    private InteractibleClick mouthDoor;

    private void OnEnable()
    {
        EventManager.Instance.OnMouthDoorOpen += MouthDoorOpen;
        if (GameManager.Instance.GetWorldState("MouthDoor"))
        {
            mouthDoor.OpenDoor();
        }
    }

    private void OnDisable()
    {
        EventManager.Instance.OnMouthDoorOpen -= MouthDoorOpen;
    }

    private void MouthDoorOpen()
    {
        Debug.Log("MouthDoor opened!");
        mouthDoor.OpenDoor();
        mouthDoor.ChangeWorldState();
    }
}
