using System.Collections;
using System.Collections.Generic;
using SuperPupSystems.Manager;
using UnityEngine;

public class PLAYERDefaultState : UINullState
{
    public bool oneTimeCameraCheck = false;
    public bool oneTimeMovementCheck = false;
    public bool oneTimeSprintCheck = false;
    public bool oneTimeSlideCheck = false;
    public bool oneTimeCrouchCheck = false;
    public bool oneTimePauseCheck = false;
    

    public override void OnStateUpdate(UIStateMachineController controller)
    {
        base.OnStateUpdate(controller);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            controller.ChangeState<PlayerGreetState>();
        }
    }
}

