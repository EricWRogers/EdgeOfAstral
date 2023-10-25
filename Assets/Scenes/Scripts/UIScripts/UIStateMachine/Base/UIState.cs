using UnityEngine;

/// <summary>
/// Base class for UIState Template's
/// </summary>
public class UIState : MonoBehaviour, IUIState
{
    [Tooltip("If this is enabled the state can take full control of the screen by locking the player's input until either the state is exited or the player presses ESC")]
    public bool fullscreen;

    public virtual void OnStateEnter(UIStateMachineController controller)
    {
        if (fullscreen)
            OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(true, OmnicatLabs.CharacterControllers.CharacterController.Instance.playerIsHidden, true);
    }

    public virtual void OnStateExit(UIStateMachineController controller)
    {
        if (fullscreen)
        {
            OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, OmnicatLabs.CharacterControllers.CharacterController.Instance.playerIsHidden, false);
        }
            
    }

    public virtual void OnStateFixedUpdate(UIStateMachineController controller)
    {

    }

    public virtual void OnStateUpdate(UIStateMachineController controller)
    {
        if (fullscreen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                controller.ChangeState(controller.nullState);
            }
        }
    }
}
