using System.Collections;
using System.Collections.Generic;
using OmnicatLabs.Timers;
using UnityEngine;

public class TUTORIALPauseMenuCheckState : UITextState
{
    public CanvasGroup playerGreetUI;
    
    [SerializeField]
    [Tooltip("This is where you assign the the reference to the player default state. It allows updates to bool checks within it")]
    public PLAYERDefaultState playerDefaultState;

    [SerializeField]
    [Tooltip("This is the keybind for movement interaction. You can change this here. MAKE SURE TO CHANGE IN CHARACTER CONTROLLER FOR CORRECT REFERENCE")]
    private KeyCode pauseMenuKey = KeyCode.Escape;

    [SerializeField]
    [Header("BOOL CHECKS")]
    [Tooltip("This is where your bool checks are logged")]
    public bool hasPressedEsc = false;
    public override void OnStateEnter(UIStateMachineController controller)
    {
        //SetInCallback(() => { Time.timeScale = 0f; });

        base.OnStateEnter(controller);
        playerGreetUI.alpha = 1f;
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
        controller.textArea.SetText(""); 
        playerGreetUI.alpha = 0f;
        //controller.ChangeState<PLAYERDefaultState>();
    }
}
