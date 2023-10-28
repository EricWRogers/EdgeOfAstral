using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTORIALMovementState : UITextState
{
    public CanvasGroup playerGreetUI;

    [SerializeField]
    [Tooltip("This is where you assign the the reference to the player default state. It allows updates to bool checks within it")]
    public PLAYERDefaultState playerDefaultState;

    [SerializeField]
    [Tooltip("This is the keybind for movement interaction. You can change this here. MAKE SURE TO CHANGE IN CHARACTER CONTROLLER FOR CORRECT REFERENCE")]
    private KeyCode playerForwardKey = KeyCode.W;
    private KeyCode playerLeftKey = KeyCode.A;
    private KeyCode playerBackKey = KeyCode.S;
    private KeyCode playerRightKey = KeyCode.D;

    [SerializeField]
    [Header("BOOL CHECKS")]
    [Tooltip("This is where your bool checks are logged")]
    public bool hasPressedW = false;
    public bool hasPressedA = false;
    public bool hasPressedS = false;
    public bool hasPressedD = false;

    public bool movementTutorialComplete = false;

    public override void OnStateEnter(UIStateMachineController controller)
    {
        base.OnStateEnter(controller);
        controller.textArea.SetText(text);
        
        if (playerGreetUI != null)
        {
            playerGreetUI.alpha = 1f;
        }
    }

    public override void OnStateUpdate(UIStateMachineController controller)
    {
        Debug.Log("Entered OnStateUpdate movement");
        base.OnStateUpdate(controller);


        // Set corresponding booleans to true once the keys are pressed
        if (Input.GetKeyDown(KeyCode.W) && !hasPressedW)
        {
            hasPressedW = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && !hasPressedA)
        {
            hasPressedA = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && !hasPressedS)
        {
            hasPressedS = true;
        }
        if (Input.GetKeyDown(KeyCode.D) && !hasPressedD)
        {
            hasPressedD = true;
        }

        if (hasPressedW && hasPressedA && hasPressedS && hasPressedD)
        {
            controller.textArea.SetText("Great! Your movement looks good.");
        }

        if (hasPressedW && hasPressedA && hasPressedS && hasPressedD)
        {
            playerDefaultState.oneTimeMovementCheck = true;
            movementTutorialComplete = true;
            controller.ChangeState<TUTORIALJumpCheckState>();
        }
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        base.OnStateExit(controller);
        controller.textArea.SetText(""); 
        playerGreetUI.alpha = 0f;
        //controller.ChangeState<PLAYERDefaultState>();
    }
}
