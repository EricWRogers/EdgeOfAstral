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
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        Time.timeScale = 1f;
        base.OnStateExit(controller);
        Time.timeScale = 1f;
    }
}
