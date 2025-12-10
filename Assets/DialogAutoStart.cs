using UnityEngine;

public class DialogAutoStart : MonoBehaviour
{
    [SerializeField]
    private DialogAsset dialogToStart;

    private void Start()
    {
        DialogManager dialogManager = FindFirstObjectByType<DialogManager>();
        if (dialogManager != null && dialogToStart != null)
        {
            dialogManager.StartDialog(dialogToStart);
        }
    }
}
