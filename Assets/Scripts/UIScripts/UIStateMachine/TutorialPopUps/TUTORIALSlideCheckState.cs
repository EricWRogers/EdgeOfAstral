using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTORIALSlideCheckState : UITextState
{
    public PLAYERDefaultState playerDefaultState;

    public bool hasPressedLeftControl = false;

   public override void OnStateEnter(UIStateMachineController controller)
    {
        base.OnStateEnter(controller);
    }

    public override void OnStateUpdate(UIStateMachineController controller)
    {
        base.OnStateUpdate(controller);

        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            hasPressedLeftControl = true;
            playerDefaultState.oneTimeSlideCheck = true;

            controller.ChangeState<TUTORIALPauseMenuCheckState>();
        }
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        base.OnStateExit(controller);
        controller.ChangeState<TUTORIALPauseMenuCheckState>();
        //controller.ChangeState<PLAYERDefaultState>();
    }
}
