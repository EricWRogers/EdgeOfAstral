using UnityEngine;
using OmnicatLabs.Tween;
using UnityEngine.InputSystem;
using OmnicatLabs.CharacterControllers;

public class GameStateController : MonoBehaviour
{
    public Canvas canvas;
    public UIStateMachineController hudController;

    public static GameStateController Instance;
    public static bool isActive = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ActivateWin()
    {
        FindObjectOfType<PlayerInput>().enabled = false;
        FindObjectOfType<MouseLook>().Lock();
        GameObject instance = Instantiate(Resources.Load("UI/WinUI") as GameObject, canvas.transform);
        instance.GetComponent<CanvasGroup>().FadeIn(.8f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ActivateLose()
    {
        Debug.Log("Called Lose");
        if (!isActive)
        {
            hudController.ChangeState(hudController.nullState);
            GameObject instance = Instantiate(Resources.Load("UI/LoseUI") as GameObject, canvas.transform);
            OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(true, true, true);
            OmnicatLabs.CharacterControllers.CharacterController.Instance.movementDir = Vector3.zero;
            OmnicatLabs.CharacterControllers.CharacterController.Instance.ChangeState(OmnicatLabs.CharacterControllers.CharacterStates.Idle);
            OmnicatLabs.CharacterControllers.CharacterController.Instance.sprinting = false;
            
            isActive = true;
            instance.GetComponent<CanvasGroup>().FadeIn(.8f);
        }
    }
}
