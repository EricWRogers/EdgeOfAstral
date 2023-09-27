using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class KeypadUIController : MonoBehaviour
{
    public TMP_Text displayText;
    public UnityEvent onCorrectPassword;

    private string input;
    private float buttonCount = 0;
    private float guesses;
    private string correctPass;

    private void Start()
    {
        correctPass = FindObjectOfType<RandNumGen>().RandNum.ToString();
        guesses = correctPass.Length;
    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q":
                input = "";
                displayText.text = input.ToString();
                OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, false, false);
                Destroy(gameObject);
                break;
            case "C":
                input = "";
                buttonCount = 0;
                displayText.text = input.ToString();
                break;
            default:
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
                input = "";
                buttonCount = 0;
                onCorrectPassword.Invoke();
            }
            else
            {
                input = "";
                displayText.text = input.ToString();
                buttonCount = 0;
            }
        }
    }
}
