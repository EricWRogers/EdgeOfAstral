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

    public void FirstCurrObjective(string task)
    {                 
        objArea.FadeIn(fadeTime);
        objText.SetText(task);
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
    }
}
