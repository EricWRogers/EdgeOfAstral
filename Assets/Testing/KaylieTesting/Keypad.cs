using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Keypad : MonoBehaviour
{

    [SerializeField] private UnityEvent correctPassword;

    private string correctPass = "12345";
    private string input;
    public TMP_Text displayText;

    private float buttonCount = 0;
    private float guesses;
    
    // Start is called before the first frame update
    void Start()
    {
        guesses = correctPass.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonCount == guesses)
        {
            if(input == correctPass)
            {
                Debug.Log("Correct Password");
                input = "";
                buttonCount = 0;
                correctPassword.Invoke();
            }
            else
            {
                input = "";
                displayText.text = input.ToString();
                buttonCount = 0;
            }
        }
    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q":
                input = "";
                displayText.text = input.ToString();
                Debug.Log("Quit");
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

    public void Test()
    {
        Debug.Log("Does the event work");
    }
}
