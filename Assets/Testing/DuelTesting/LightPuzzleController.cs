using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class LightPuzzleController : MonoBehaviour
{
    public bool lit = false;

    //Changing the light state and sending a debug message
    public void ChangeLightState()
    {
        lit = !lit;

        string boolTest;
        if (lit)
            boolTest = "lit";
        else
            boolTest = "not lit";
         
        
        Debug.Log(this.gameObject.name + " is " + boolTest);
    }
}
