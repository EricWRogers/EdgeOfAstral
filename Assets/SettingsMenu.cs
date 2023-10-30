using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public UIStateMachineController controller;
    public Button backButton;
    public CanvasGroup mainMenu;
    private void Start()
    {
        backButton.onClick.AddListener(ExitToMainMenu);
    }

    private void PostPlay()
    {
        backButton.onClick.RemoveListener(ExitToMainMenu);
        backButton.onClick.AddListener(Exit);
    }

    public void ExitToMainMenu()
    {
        GetComponent<CanvasGroup>().alpha = 0f;
        //controller.ChangeState(controller.nullState);
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        mainMenu.interactable = true;
        GetComponentInChildren<Slider>().interactable = false;
    }

    public void Exit()
    {
        GetComponent<CanvasGroup>().alpha = 0f;
        controller.ChangeState<HUDPauseState>();
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        GetComponentInChildren<Slider>().interactable = false;
    }
}
