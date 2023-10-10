using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;

public class LightPuzzleLights : MonoBehaviour
{
    public bool lit = false;

    public UnityEvent lightStateChange = new UnityEvent();

    //Changing the light state and sending a debug message
    public void ChangeLightState()
    {
        lit = !lit;

        lightStateChange.Invoke();

        string boolTest;
        if (lit)
            boolTest = "lit";
        else
            boolTest = "not lit";
         
        
        Debug.Log(this.gameObject.name + " is " + boolTest);
    }
}
