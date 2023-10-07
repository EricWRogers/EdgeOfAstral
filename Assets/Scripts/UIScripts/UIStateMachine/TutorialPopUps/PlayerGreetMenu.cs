using UnityEngine;
using UnityEngine.SceneManagement;
using OmnicatLabs.Tween;
using OmnicatLabs.Timers;

public class PlayerGreetMenu : MonoBehaviour
{
    public static bool GreetMessageIsActive = false;
    public static bool GameIsPaused = false;
    public float fadeTime = .3f;
    public CanvasGroup playerGreetUI;
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
        GreetMessageIsActive = false;
        controller.ChangeState<TUTORIALCameraCheckState>();
        OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, false, false);
    }

    public void SkipTutorial()
    {
        Time.timeScale = 1f;
        GreetMessageIsActive = false;
        controller.ChangeState<PLAYERDefaultState>();
        OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, false, false);
    }
}
