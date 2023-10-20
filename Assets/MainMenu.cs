using UnityEngine;
using OmnicatLabs.Tween;

public class MainMenu : MonoBehaviour
{
    public UIStateMachineController controller;
    public OpeningCutscene cutscene;
    public CanvasGroup settingsMenu;
    public float menuCloseTime = 2f;

    private void Start()
    {
        OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(true, true, true);
    }

    public void Play()
    {
        GetComponent<CanvasGroup>().FadeOut(menuCloseTime, StartGame, EasingFunctions.Ease.EaseOutQuart);
        controller.ChangeState(controller.nullState);
    }

    private void StartGame()
    {
        GetComponent<Dialogue>().TriggerDialogue();
        //Play explosion sound
        OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, true, false);
        cutscene.StartCutscene();
    }

    public void Settings()
    {
        settingsMenu.alpha = 1f;
        settingsMenu.interactable = true;
        settingsMenu.blocksRaycasts = true;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
