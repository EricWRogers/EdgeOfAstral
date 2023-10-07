using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTORIALSprintCheckState : UITextState
{
    public override void OnStateEnter(UIStateMachineController controller)
    {
        base.OnStateEnter(controller);
        controller.textArea.SetText(text);
    }

    public override void OnStateUpdate(UIStateMachineController controller)
    {
        base.OnStateUpdate(controller);
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        base.OnStateExit(controller);
        controller.ChangeState<TUTORIALCrouchCheckState>();
        //controller.ChangeState<PLAYERDefaultState>();
    }
}
