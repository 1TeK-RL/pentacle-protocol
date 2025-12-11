using UnityEngine;

public class DialogAutoStart : MonoBehaviour
{
    [SerializeField]
    private DialogAsset dialogToStart;

    [SerializeField]
    private DialogAsset AlternativeDialog;

    [SerializeField]
    private GameObject previousPOV;

    [SerializeField]
    private CollectibleItem itemToCheck;

    [SerializeField]
    private AnimatedSprite interlocutorSprite;

    private void Start()
    {
        DialogManager dialogManager = FindFirstObjectByType<DialogManager>();
        if (dialogManager != null && dialogToStart != null && AlternativeDialog != null)
        {
            dialogManager.SetInterlocutorSprite(interlocutorSprite);
            dialogManager.SetCharonVoice();
            dialogManager.SetPreviousPOV(previousPOV);
            if (itemToCheck != null && GameManager.Instance.IsItemPentacled(itemToCheck))
            {
                dialogManager.StartDialog(AlternativeDialog);
            }
            else
            {
                dialogManager.StartDialog(dialogToStart);
            }
        }
    }
}
