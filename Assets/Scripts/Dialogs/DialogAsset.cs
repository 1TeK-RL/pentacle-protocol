using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog/Dialog Asset")]
public class DialogAsset : ScriptableObject
{
    public List<DialogLine> lines = new List<DialogLine>();

    public string interlocutorName; 
    public void DebugThis(string message)
    {
        GameManager.Instance.DebugThis(message);
    }

    public void GivePentacleItem(CollectibleItem item)
    {
        GameManager.Instance.AddItem(item);
    }

    public void OpenMouthDoor()
    {
        EventManager.Instance.OpenMouthDoor();
    }

    public void ChangeAnimationFrames(AnimationFrames frames)
    {
        EventManager.Instance.ChangeAnimationFrames(frames);
    }

    public void PlaySoundEye()
    {

    }

    public void ChangeAmbianceSound()
    {
        AudioManager.Instance.StopAmbiance();
        AudioManager.Instance.ReleaseAmbiance();
        AudioManager.Instance.SetHospitalAmbiance();
        AudioManager.Instance.StartAmbiance();
    }
}

[Serializable]
public class DialogLine
{
    [TextArea(2, 4)]
    public string npcText;

    public DialogAnswer[] answers = new DialogAnswer[4]; // Max 4 answers
}

[Serializable]
public class DialogAnswer
{
    public string text;

    public int nextLineIndex = -1; // -1 = end of dialog

    public UnityEngine.Events.UnityEvent onSelected;
}