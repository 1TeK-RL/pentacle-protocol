using UnityEngine;

public class InteractibleNPC : MonoBehaviour
{
    [SerializeField] private string povName;

    [SerializeField] private GameObject nextRoomPOV;

    [SerializeField] private UnityEngine.Events.UnityEvent onClick;

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

        Debug.Log(nextRoomPOV);
        EventManager.Instance.PlayerMove(nextRoomPOV.transform.position, nextRoomPOV.transform.rotation, true, nextRoomPOV.GetComponent<ZoneType>().Type);

        if (onClick != null)
        {
            onClick.Invoke();
        }
    }
}
