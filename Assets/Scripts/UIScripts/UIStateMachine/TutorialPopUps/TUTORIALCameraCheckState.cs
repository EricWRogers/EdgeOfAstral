using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TUTORIALCameraCheckState : UITextState
{
    public PLAYERDefaultState playerDefaultState;
    public bool hasMouseMoved = false; // Flag to track mouse movement
    public float totalRotationX = 0f;
    public float totalRotationY = 0f;
    public float requiredRotationAmount = 180f;

    public override void OnStateEnter(UIStateMachineController controller)
    {
        base.OnStateEnter(controller);

        if (controller.textArea != null)
        {
            controller.textArea.SetText(text);
        }
        else
        {
            Debug.LogError("Text Area is not assigned in the UIStateMachineController.");
        }

        hasMouseMoved = false; // Reset the flag when entering the state
    }

    public override void OnStateUpdate(UIStateMachineController controller)
    {
        base.OnStateUpdate(controller);

        // Check for mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (!hasMouseMoved)
        {
            totalRotationX += Input.GetAxis("Mouse X");
            totalRotationY += Input.GetAxis("Mouse Y");

            if (Mathf.Abs(totalRotationX) >= requiredRotationAmount && Mathf.Abs(totalRotationY) >= requiredRotationAmount)
            {
                controller.textArea.SetText("Great! Let's move on to player movement");
                hasMouseMoved = true;

                playerDefaultState.oneTimeCameraCheck = true;

                controller.ChangeState<TUTORIALMovementState>();
            }
        }
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        base.OnStateExit(controller);
        Debug.Log("Has entered On State Exit");
        
        controller.textArea.SetText(""); 
    }
}