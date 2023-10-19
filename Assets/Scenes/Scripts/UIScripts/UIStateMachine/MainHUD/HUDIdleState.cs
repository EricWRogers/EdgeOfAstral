using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDIdleState : UINullState
{
    public override void OnStateUpdate(UIStateMachineController controller)
    {
        base.OnStateUpdate(controller);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controller.ChangeState<HUDPauseState>();
        }
    }
}
