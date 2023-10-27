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
    [TextArea]
    public string startingObjective;
    public string currObjective;
    
    private Timer currentTimer;

    public static ObjectiveText instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void PostPlay()
    {
        FirstCurrObjective();
    }

    public void FirstCurrObjective()
    {                 
        objArea.FadeIn(fadeTime);
        objText.SetText(startingObjective);
    }

    public void SetCurrObjective()
    {

        if (currentTimer != null)
        {
            TimerManager.Instance.Stop(currentTimer);
        }

        Debug.Log("Task is " + currObjective);

        objArea.FadeOut(fadeTime,
           () => {
               TimerManager.Instance.CreateTimer(0.1f,
               () => {
                   Debug.Log("In the timer ");
                   objText.SetText(currObjective);
                   objArea.FadeIn(fadeTime);
               }, out currentTimer);
           }
        );
    }
}
