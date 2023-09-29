using UnityEngine;
using TMPro;
using UnityEngine.Events;
using SuperPupSystems.Helper;

public class KeypadUIController : MonoBehaviour
{
    public TMP_Text displayText;
    public UnityEvent onCorrectPassword;
    public Timer wrongTimer;
    public Timer rightTimer;
    private string input;
    private float buttonCount = 0;
    private float guesses;
    private string correctPass;
    public GameObject keypadUI;

    private void Start()
    {
        //correctPass = "123";
        correctPass = FindObjectOfType<RandNumGen>().RandNum.ToString();
        guesses = correctPass.Length;
    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q":
                //Debug.Log("Quit");
                input = "";
                displayText.text = input.ToString();
                OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, false, false);
                Destroy(gameObject);
                break;
            case "C":
                //Debug.Log("Clear");
                input = "";
                buttonCount = 0;
                displayText.text = input.ToString();
                break;
            default:
                //Debug.Log("Default");
                buttonCount++;
                input += valueEntered;
                displayText.text = input.ToString();
                break;
        }
    }

    void Update()
    {
        if (buttonCount == guesses)
        {
            if (input == correctPass)
            {
                displayText.text = "<color=#15F00B>" + input.ToString();
                buttonCount = 0;
                Debug.Log("Correct");
                onCorrectPassword.Invoke();
            }
            else
            {
                displayText.text = "<color=#F00B0B>" + input.ToString();
                wrongTimer.StartTimer(wrongTimer.countDownTime, wrongTimer.autoRestart);
                buttonCount = 0;
            }
        }
    }

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
