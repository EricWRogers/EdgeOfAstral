using UnityEngine;
using TMPro;
using OmnicatLabs.Timers;
using OmnicatLabs.Tween;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public CanvasGroup dialogueArea;
    public float dialogueFadeTime = .3f;

    private TextMeshProUGUI textArea;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        textArea = dialogueArea.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ShowDialogue(string message)
    {
        textArea.SetText(message);

        dialogueArea.FadeIn(dialogueFadeTime);
    }

    public void ShowDialogue(string message, float timeOnScreen)
    {
        textArea.SetText(message);

        dialogueArea.FadeIn(dialogueFadeTime, 
            () => { TimerManager.Instance.CreateTimer(timeOnScreen, 
                () => {
                    dialogueArea.FadeOut(dialogueFadeTime);
                }); 
            });
    }

    public void ClearDialogue()
    {
        textArea.SetText("");
        textArea.CrossFadeAlpha(0f, dialogueFadeTime, false);
    }
}
