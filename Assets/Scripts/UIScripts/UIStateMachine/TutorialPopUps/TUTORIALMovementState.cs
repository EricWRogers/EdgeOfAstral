using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTORIALMovementState : UITextState
{
    public bool hasPressedW = false;
    public bool hasPressedA = false;
    public bool hasPressedS = false;
    public bool hasPressedD = false;

    public bool movementTutorialComplete = false;

    public PLAYERDefaultState playerDefaultState;

    public override void OnStateEnter(UIStateMachineController controller)
    {
        base.OnStateEnter(controller);
        controller.textArea.SetText(text);
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
            controller.ChangeState<TUTORIALSprintCheckState>();
        }
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        base.OnStateExit(controller);
        //controller.ChangeState<PLAYERDefaultState>();
    }
}
