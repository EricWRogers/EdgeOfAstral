using UnityEngine;
using OmnicatLabs.Tween;
using UnityEngine.InputSystem;
using OmnicatLabs.CharacterControllers;

public class GameStateController : MonoBehaviour
{
    public Canvas canvas;

    public static GameStateController Instance;

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
        OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(true, true, true);
        OmnicatLabs.CharacterControllers.CharacterController.Instance.movementDir = Vector3.zero;
        OmnicatLabs.CharacterControllers.CharacterController.Instance.ChangeState(OmnicatLabs.CharacterControllers.CharacterStates.Idle);
        OmnicatLabs.CharacterControllers.CharacterController.Instance.sprinting = false;
        //FindObjectOfType<PlayerInput>().enabled = false;
        //FindObjectOfType<MouseLook>().Lock();
        Debug.Log("Called Lose");
        GameObject instance = Instantiate(Resources.Load("UI/LoseUI") as GameObject, canvas.transform);
        instance.GetComponent<CanvasGroup>().FadeIn(.8f);
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
    }
}
