using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTORIALSlideCheckState : UITextState
{
   public override void OnStateEnter(UIStateMachineController controller)
    {
        base.OnStateEnter(controller);
    }

    public override void OnStateUpdate(UIStateMachineController controller)
    {
        base.OnStateUpdate(controller);
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        base.OnStateExit(controller);
        controller.ChangeState<TUTORIALPauseMenuCheckState>();
        //controller.ChangeState<PLAYERDefaultState>();
    }
}
