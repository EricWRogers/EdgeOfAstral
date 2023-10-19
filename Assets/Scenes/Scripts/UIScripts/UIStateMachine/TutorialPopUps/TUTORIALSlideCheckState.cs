using System.Collections;
using System.Collections.Generic;
using OmnicatLabs.StatefulObject;
using UnityEngine;

public class TUTORIALSlideCheckState : UITextState
{
    public CanvasGroup playerGreetUI;
    
    [SerializeField]
    [Tooltip("This is where you assign the the reference to the player default state. It allows updates to bool checks within it")]
    public PLAYERDefaultState playerDefaultState;

    [SerializeField]
    [Header("BOOL CHECKS")]
    [Tooltip("This is where your bool checks are logged")]
    public bool hasPressedCrouchButton = false;
    public bool isSprinting = false;

   public override void OnStateEnter(UIStateMachineController controller)
    {
        base.OnStateEnter(controller);
        playerGreetUI.alpha = 1f;
    }

    public override void OnStateUpdate(UIStateMachineController controller)
    {
        base.OnStateUpdate(controller);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;

            if (isSprinting && Input.GetKeyDown(KeyCode.LeftControl))
            {
                hasPressedCrouchButton = true;
                playerDefaultState.oneTimeSlideCheck = true;

                controller.ChangeState<TUTORIALPauseMenuCheckState>();
            }
        }
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        base.OnStateExit(controller);
        controller.textArea.SetText(""); 
        playerGreetUI.alpha = 0f;
        //controller.ChangeState<TUTORIALPauseMenuCheckState>();
        //controller.ChangeState<PLAYERDefaultState>();
    }
}
