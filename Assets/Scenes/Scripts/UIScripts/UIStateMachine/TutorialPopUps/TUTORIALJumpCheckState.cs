using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTORIALJumpCheckState : UITextState
{
    public CanvasGroup playerGreetUI;
    
    [SerializeField]
    [Tooltip("This is where you assign the the reference to the player default state. It allows updates to bool checks within it")]
    public PLAYERDefaultState playerDefaultState;

    [SerializeField]
    [Tooltip("This is the keybind for movement interaction. You can change this here. MAKE SURE TO CHANGE IN CHARACTER CONTROLLER FOR CORRECT REFERENCE")]
    private KeyCode jumpKey = KeyCode.Space;

    [SerializeField]
    [Header("BOOL CHECKS")]
    [Tooltip("This is where your bool checks are logged")]
    public bool hasPressedSpace = false;

    public override void OnStateEnter(UIStateMachineController controller)
    {
        base.OnStateEnter(controller);
        playerGreetUI.alpha = 1f;
        //controller.canvas.Alpha
        controller.textArea.SetText(text);
    }

    public override void OnStateUpdate(UIStateMachineController controller)
    {
        base.OnStateUpdate(controller);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasPressedSpace = true;
            playerDefaultState.oneTimeJumpCheck = true;

            controller.ChangeState<TUTORIALSprintCheckState>();
        }
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        base.OnStateExit(controller);
        controller.textArea.SetText(""); 
        playerGreetUI.alpha = 0f;
        //controller.ChangeState<TUTORIALSprintCheckState>();
        //controller.ChangeState<PLAYERDefaultState>();
    }
}
