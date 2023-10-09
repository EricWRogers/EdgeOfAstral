using System.Collections;
using System.Collections.Generic;
using OmnicatLabs.Timers;
using UnityEngine;

public class TUTORIALPauseMenuCheckState : UITextState
{
    public PLAYERDefaultState playerDefaultState;
    public bool hasPressedEsc = false;
    public override void OnStateEnter(UIStateMachineController controller)
    {
        //SetInCallback(() => { Time.timeScale = 0f; });

        base.OnStateEnter(controller);
    }

    public override void OnStateUpdate(UIStateMachineController controller)
    {
        base.OnStateUpdate(controller);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SetInCallback(() => { Time.timeScale = 0f; });
            hasPressedEsc = true;
            playerDefaultState.oneTimePauseCheck = true;

            controller.textArea.SetText(
                "Perfect! You have now completed the tutorial. With these skills you will be one step ahead of your enemies..but only one. Good luck.");

            controller.ChangeState<PLAYERDefaultState>();
        }
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        //Time.timeScale = 1f;
        base.OnStateExit(controller);
        controller.ChangeState<PLAYERDefaultState>();
    }
}
