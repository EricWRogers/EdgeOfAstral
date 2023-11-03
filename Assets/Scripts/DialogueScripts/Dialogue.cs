using UnityEngine;
using OmnicatLabs.Timers;

public class Dialogue : MonoBehaviour
{
    [TextArea]
    public string message;
    public bool oneTime = false;
    public float timeShown = 5f;
    public float lockoutTime = 5f;
    public Dialogue followUp;

    private bool hasShown = false;
    private bool hasSetObjective = false;
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
            if (oneTime)
            {
                if (!hasShown)
                {
                    if (TryGetComponent(out ChangeObjective changeObjective))
                    {
                        changeObjective.Change();
                        hasSetObjective = true;
                    }
                    if (timeShown == 0f)
                    {
                        DialogueManager.Instance.ShowDialogue(message);
                    }
                    else
                    {
                        if (followUp != null)
                        {
                            DialogueManager.Instance.ShowDialogue(message, timeShown, () => followUp.TriggerDialogue());
                        }
                        else
                        {
                            DialogueManager.Instance.ShowDialogue(message, timeShown);
                        }
                    
                    }
                    hasShown = true;
                    canShow = false;
                }
            }
            else
            {
                //Even if the dialogue will display more than once, the objective will only get set once
                if (!hasSetObjective && TryGetComponent(out ChangeObjective changeObjective))
                {
                    changeObjective.Change();
                    hasSetObjective = true;
                }
                if (timeShown == 0f)
                {
                    DialogueManager.Instance.ShowDialogue(message);
                }
                else
                {
                    if (followUp != null)
                    {
                       DialogueManager.Instance.ShowDialogue(message, timeShown, () => followUp.TriggerDialogue());
                    }
                    else
                    {
                        DialogueManager.Instance.ShowDialogue(message, timeShown);
                    }
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
