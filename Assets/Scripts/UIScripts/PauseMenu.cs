using UnityEngine;
using UnityEngine.SceneManagement;
using OmnicatLabs.Tween;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public float fadeTime = .3f;
    public CanvasGroup pauseMenuUI;
    public UIStateMachineController controller;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (GameIsPaused)
        //    {
        //        Resume();
        //    }

        //    else
        //    {
        //        Pause();
        //    }
        //}
    }

    public void Resume()
    {
        //Time.timeScale = 1f;
        //pauseMenuUI.FadeOut(fadeTime, null, EasingFunctions.Ease.EaseOutQuart);
        //GameIsPaused = false;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        Time.timeScale = 1f;
        controller.ChangeState<HUDIdleState>();
        OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, false, false);
    }

    void Pause()
    {
        pauseMenuUI.FadeIn(fadeTime, () => { Time.timeScale = 0f; }, EasingFunctions.Ease.EaseOutQuart);
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}