using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDPauseState : UIGroupState
{
    public override void OnStateEnter(UIStateMachineController controller)
    {
        SetInCallback(() => { Time.timeScale = 0f; });

        base.OnStateEnter(controller);

    }

    public override void OnStateUpdate(UIStateMachineController controller)
    {
        base.OnStateUpdate(controller);


    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        Time.timeScale = 1f;
        base.OnStateExit(controller);
    }
}
