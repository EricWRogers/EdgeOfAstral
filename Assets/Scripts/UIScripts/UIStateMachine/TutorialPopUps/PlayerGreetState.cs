using UnityEngine;
using UnityEngine.SceneManagement;
using OmnicatLabs.Tween;
using OmnicatLabs.Timers;

public class PlayerGreetState : UIGroupState
{
    public override void OnStateEnter(UIStateMachineController controller)
    {
        SetInCallback(() => { Time.timeScale = 0f; });
        base.OnStateEnter(controller);
        OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, false, true);
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
