using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTORIALCrouchCheckState : UITextState
{
    public bool hasPressedLCtrl = false;

    public override void OnStateEnter(UIStateMachineController controller)
    {
        base.OnStateEnter(controller);
        controller.textArea.SetText(text);
    }

    public override void OnStateUpdate(UIStateMachineController controller)
    {
        base.OnStateUpdate(controller);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            hasPressedLCtrl = true;
        }
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        base.OnStateExit(controller);
        controller.ChangeState<TUTORIALSlideCheckState>();
        //controller.ChangeState<PLAYERDefaultState>();
    }
}
