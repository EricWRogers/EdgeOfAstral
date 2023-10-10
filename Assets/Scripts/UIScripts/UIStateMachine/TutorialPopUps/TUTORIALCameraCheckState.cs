using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OmnicatLabs.Tween;
using OmnicatLabs.Timers;

public class TUTORIALCameraCheckState : UITextState
{
    public CanvasGroup playerGreetUI;

    [SerializeField]
    [Tooltip("This is where you assign the the reference to the player default state. It allows updates to bool checks within it")]
    public PLAYERDefaultState playerDefaultState;

    [SerializeField]
    [Header("BOOL CHECKS")]
    [Tooltip("This is where your bool & camera angle checks are logged")]
    public bool hasMouseMoved = false; // Flag to track mouse movement
    public float totalRotationX = 0f;
    public float totalRotationY = 0f;
    public float requiredRotationAmount = 180f;

    public override void OnStateEnter(UIStateMachineController controller)
    {
        base.OnStateEnter(controller);
        playerGreetUI.alpha = 1f;

        /*if (playerGreetUI != null)
        {
            playerGreetUI.alpha = 1f;
        }

        else
        {
            Debug.LogError("CanvasGroup or Button reference is not assigned.");
        }
        */

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

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, false, false);

        playerGreetUI.alpha = 1f;

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
        playerGreetUI.alpha = 0f;
        Debug.Log("Has entered On State Exit");
        
        controller.textArea.SetText(""); 
    }
}