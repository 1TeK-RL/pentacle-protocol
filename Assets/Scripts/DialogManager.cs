using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public DialogAsset dialog;

    [SerializeField]
    private TMP_Text interlocutorText;

    [SerializeField]
    private TMP_Text interlocutorName;

    [SerializeField]
    private ScrollRect scrollRect;

    [SerializeField]
    private GameObject dialogBox;

    [SerializeField]
    private List<AnswerButton> answerButtons;


    private int currentIndex;
    private Coroutine revealCoroutine;
    private string currentLine;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartDialog(DialogAsset asset)
    {
        dialog = asset;
        currentIndex = 0;
        dialogBox.SetActive(true);
        interlocutorName.text = asset.interlocutorName;
        ShowLine();
    }

    public void ShowLine()
    {
        currentLine = dialog.lines[currentIndex].npcText;

        // Hide Buttons and the arrow, they will be activated later
        foreach (var button in answerButtons)
        {
            button.gameObject.SetActive(false);
            button.HideArrow();
        }

        // Display NPC text word by word
        RevealLine(currentLine, interlocutorText, 0.03f);
    }

    private void DisplayAnswers()
    {
        int i = 0;
        foreach (var answer in dialog.lines[currentIndex].answers)
        {

            if (!string.IsNullOrEmpty(answer.text))
            {
                answerButtons[i].gameObject.SetActive(true);
                answerButtons[i].GetComponentInChildren<TMP_Text>().text = answer.text;

                int index = i;
                answerButtons[i].GetComponent<Button>().onClick.RemoveAllListeners();
                answerButtons[i].GetComponent<Button>().onClick.AddListener(() => SelectAnswer(index));
            }

            i += 1;
        }

        for (int j = i; j < 4; j++)
        {
            answerButtons[j].gameObject.SetActive(false);
        }
    }

    public void SelectAnswer(int index)
    {
        var answer = dialog.lines[currentIndex].answers[index];

        answer.onSelected?.Invoke();

        if (answer.nextLineIndex >= 0)
        {
            currentIndex = answer.nextLineIndex;
            ShowLine();
        }
        else
        {
            EndDialog(); // because index -1 is end dialog
        }
    }

    private void RevealLine(string line, TMP_Text uiText, float revealDelay)
    {
        // Stop previous reveal if still running
        if (revealCoroutine != null)
            StopCoroutine(revealCoroutine);

        revealCoroutine = StartCoroutine(RevealCoroutine(line, uiText, revealDelay));
    }

    private IEnumerator RevealCoroutine(string line, TMP_Text uiText, float revealDelay)
    {
        uiText.text = "";
        for (int i = 0; i <= line.Length; i++)
        {
            // sorcellerie mais correspond a Substring
            uiText.text = line[..i];

            LayoutRebuilder.ForceRebuildLayoutImmediate(
                uiText.transform as RectTransform
            );

            // scroll down
            scrollRect.verticalNormalizedPosition = 0f;

            // when the text is displayed entirely, show answers
            if ( i == line.Length - 1 )
            {
                DisplayAnswers();
            }

            yield return new WaitForSeconds(revealDelay);
        }
    }

    public void SkipReveal()
    {
        Debug.Log("Reveal skipped");
        StopCoroutine(revealCoroutine);
        interlocutorText.text = currentLine;
        // scroll down
        scrollRect.verticalNormalizedPosition = 0f;
        DisplayAnswers();
    }

    void EndDialog()
    {   
        Debug.Log("Dialog ended");
        dialogBox.SetActive(false);
    }

}