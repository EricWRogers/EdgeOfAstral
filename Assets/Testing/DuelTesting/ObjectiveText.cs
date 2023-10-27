using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OmnicatLabs.Timers;
using OmnicatLabs.Tween;
using UnityEngine.Events;

public class ObjectiveText : MonoBehaviour
{
    public TextMeshProUGUI objText;
    public CanvasGroup objArea;
    public float fadeTime = 2f;

    private Timer currentTimer;

    private void Start()
    {
        SetCurrObjective("it works now");
        TimerManager.Instance.CreateTimer(5.0f,
               () => {
                   SetCurrObjective("it works again");
               }, out currentTimer);
    }

    public void SetCurrObjectiveWrapper(string task)
    {
        SetCurrObjective(task);
    }

    public void SetCurrObjective(string task)
    {

        if (currentTimer != null)
        {
            TimerManager.Instance.Stop(currentTimer);
        }

        Debug.Log("Task is " + task);

        objArea.FadeOut(fadeTime,
           () => {
               TimerManager.Instance.CreateTimer(0.1f,
               () => {
                   Debug.Log("In the timer ");
                   objText.SetText(task);
                   objArea.FadeIn(fadeTime);
               }, out currentTimer);
           }
        );
        return;
    }
}
