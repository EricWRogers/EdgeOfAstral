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
        GetComponent<Dialogue>().TriggerDialogue();
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
        FindObjectOfType<PlayerInput>().enabled = false;
        FindObjectOfType<MouseLook>().Lock();
        GameObject instance = Instantiate(Resources.Load("UI/LoseUI") as GameObject, canvas.transform);
        instance.GetComponent<CanvasGroup>().FadeIn(.8f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
