using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public float fadeTime = .3f;
    public CanvasGroup pauseMenuUI;
    public UIStateMachineController controller;

    public void Resume()
    {
        controller.ChangeState<HUDIdleState>();
    }

    public void Settings()
    {
        controller.ChangeState<HUDSettingsMenu>();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}