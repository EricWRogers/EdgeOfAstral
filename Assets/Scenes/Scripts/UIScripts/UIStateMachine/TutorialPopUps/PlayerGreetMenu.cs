using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using OmnicatLabs.Tween;
using OmnicatLabs.Timers;

public class PlayerGreetMenu : MonoBehaviour
{
    public static bool GreetMessageIsActive = false;
    public static bool GameIsPaused = false;
    public float fadeTime = .3f;
    public CanvasGroup playerGreetUI;
    public Button acceptButton;
    public Button declineButton;
    public UIStateMachineController controller;

    public void ResumeGame()
    {
        Time.timeScale = 0f;
        controller.ChangeState<PLAYERDefaultState>();
        OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, false, true);
    }

    void PlayerGreetMessage()
    {
        playerGreetUI.FadeIn(fadeTime, () => { Time.timeScale = 0f; }, EasingFunctions.Ease.EaseOutQuart);
        GreetMessageIsActive = true;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartTutorial()
    {
        Time.timeScale = 1f;
        GreetMessageIsActive = true;
        controller.ChangeState<TUTORIALCameraCheckState>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerGreetUI != null && acceptButton != null && declineButton != null)
        {
            Debug.Log("Has entered button if statement");

            acceptButton.interactable = false;
            declineButton.interactable = false;
            playerGreetUI.alpha = 0f;
        }

        else
        {
            Debug.LogError("CanvasGroup or Button reference is not assigned.");
        }
        
        OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, true, false);
    }

    public void SkipTutorial()
    {
        Time.timeScale = 1f;
        GreetMessageIsActive = false;
        controller.ChangeState<PLAYERDefaultState>();
        OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, false, false);
    }
}
