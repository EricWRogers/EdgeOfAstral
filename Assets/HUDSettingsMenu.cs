using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDSettingsMenu : UIGroupState
{
    public CanvasGroup mainMenu;

    public override void OnStateEnter(UIStateMachineController controller)
    {
        SetInCallback(() => { Time.timeScale = 0f; });
        base.OnStateEnter(controller);
        
        mainMenu.alpha = 0f;
        mainMenu.interactable = false;
        group.interactable = true;
        group.blocksRaycasts = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        base.OnStateExit(controller);
    }
}
