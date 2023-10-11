using UnityEngine;
using OmnicatLabs.Timers;

public class Dialogue : MonoBehaviour
{
    [TextArea]
    public string message;
    public bool oneTime = false;
    public float timeShown = 5f;
    public float lockoutTime = 5f;

    private bool hasShown = false;
    private bool canShow = true;

    public virtual void TriggerDialogue()
    {
        if (DialogueManager.Instance == null)
        {
            Debug.LogError("Could not find a DialogueManager in the scene");
            return;
        }

        if (canShow)
        {
            if (oneTime && !hasShown)
            {
                if (timeShown == 0f)
                {
                    DialogueManager.Instance.ShowDialogue(message);
                }
                else
                {
                    DialogueManager.Instance.ShowDialogue(message, timeShown);
                }
                hasShown = true;
            }
            else
            {
                if (timeShown == 0f)
                {
                    DialogueManager.Instance.ShowDialogue(message);
                }
                else
                {
                    DialogueManager.Instance.ShowDialogue(message, timeShown);
                }
            }
            canShow = false;
            TimerManager.Instance.CreateTimer(lockoutTime, () => { canShow = true; });
        }
    }

    public virtual void CloseDialogue()
    {
        DialogueManager.Instance.ClearDialogue();
    }
}
