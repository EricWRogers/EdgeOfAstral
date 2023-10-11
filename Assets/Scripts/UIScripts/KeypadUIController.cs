using UnityEngine;
using TMPro;
using UnityEngine.Events;
using OmnicatLabs.Timers;

public class KeypadUIController : MonoBehaviour
{
    public TMP_Text displayText;
    public UnityEvent onCorrectPassword;
    public UnityEvent onIncorrectPassword;
    public float timeAfterSubmit = 1f;
    private string input;
    private float buttonCount = 0;
    private float guesses;
    [HideInInspector]
    public string correctPass;
    public GameObject keypadUI;

    private void Start()
    {
        //correctPass = "123";
        //correctPass = FindObjectOfType<RandNumGen>().RandNum.ToString();
        guesses = correctPass.Length;
    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q":
                //Debug.Log("Quit");
                Quit();
                break;
            case "C":
                //Debug.Log("Clear");
                Clear();
                break;
            default:
                //Debug.Log("Default");
                if (buttonCount < 4)
                {
                    buttonCount++;
                    input += valueEntered;
                    displayText.text = input.ToString();
                }
                break;
        }
    }

    public void Quit()
    {
        input = "";
        displayText.text = input.ToString();
        OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, OmnicatLabs.CharacterControllers.CharacterController.Instance.playerIsHidden, false);
        Destroy(gameObject);
    }

    public void Clear()
    {
        input = "";
        buttonCount = 0;
        displayText.text = input.ToString();
    }

    public void Submit()
    {
        if (input == correctPass)
        {
            displayText.text = "<color=#15F00B>" + input.ToString();
            TimerManager.Instance.CreateTimer(timeAfterSubmit, () => { Quit(); });
            onCorrectPassword.Invoke();
        }
        else
        {
            displayText.text = "<color=#F00B0B>" + input.ToString();
            onIncorrectPassword.Invoke();
            TimerManager.Instance.CreateTimer(timeAfterSubmit, () => { Clear(); });
        }
    }

    //void Update()
    //{
    //    if (buttonCount == guesses)
    //    {
    //        if (input == correctPass)
    //        {
    //            displayText.text = "<color=#15F00B>" + input.ToString();
    //            buttonCount = 0;
    //            Debug.Log("Correct");
    //            onCorrectPassword.Invoke();
    //        }
    //        else
    //        {
    //            displayText.text = "<color=#F00B0B>" + input.ToString();
    //            //wrongTimer.StartTimer(wrongTimer.countDownTime, wrongTimer.autoRestart);
    //            buttonCount = 0;
    //        }
    //    }
    //}

    public void ClearInput()
    {
        input = "";
        displayText.text = input.ToString();
    }

    public void CloseMenu()
    {
        keypadUI.SetActive(false);
    }
}
