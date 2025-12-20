using UnityEngine;

public class DialogAutoStart : MonoBehaviour
{
    [SerializeField]
    private DialogAsset dialogToStart;

    [SerializeField]
    private DialogAsset AlternativeDialog;

    [SerializeField]
    private GameObject hospitalPOV;

    [SerializeField]
    private GameObject prisonPOV;

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
            dialogManager.SetPreviousPOV(hospitalPOV);
            if (itemToCheck != null && GameManager.Instance.IsItemPentacled(itemToCheck))
            {
                dialogManager.StartDialog(AlternativeDialog);
                dialogManager.SetPreviousPOV(prisonPOV);
            }
            else
            {
                dialogManager.StartDialog(dialogToStart);
                dialogManager.SetPreviousPOV(hospitalPOV);
            }
        }

        AudioManager.Instance.SetCarAmbiance();
        AudioManager.Instance.StartAmbiance();
    }
}
