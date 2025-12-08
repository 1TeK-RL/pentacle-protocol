using UnityEngine;

public class InteractibleClick : MonoBehaviour
{
    [SerializeField] private string povName;

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
        if (!string.IsNullOrEmpty(povName))
        {
            GameManager.Instance.SetWorldState(povName);
        }

        EventManager.Instance.PlayerMove(nextRoomPOV.transform.position, nextRoomPOV.transform.rotation);
    }
}
