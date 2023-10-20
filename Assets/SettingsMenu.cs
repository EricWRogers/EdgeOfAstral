using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public UIStateMachineController controller;
    public MainMenu menu;

    public void Exit()
    {
        GetComponent<CanvasGroup>().alpha = 0f;
        controller.ChangeState(controller.nullState);
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
