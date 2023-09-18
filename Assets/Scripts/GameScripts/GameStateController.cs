using UnityEngine;
using OmnicatLabs.Tween;
using UnityEngine.InputSystem;
using OmnicatLabs.CharacterControllers;

public class GameStateController : MonoBehaviour
{
    public static void ActivateWin()
    {
        FindObjectOfType<PlayerInput>().enabled = false;
        FindObjectOfType<MouseLook>().Lock();
        GameObject instance = Instantiate(Resources.Load("UI/WinUI") as GameObject, FindObjectOfType<Canvas>().transform);
        instance.GetComponent<CanvasGroup>().FadeIn(.8f);
    }

    public static void ActivateLose()
    {
        FindObjectOfType<PlayerInput>().enabled = false;
        FindObjectOfType<MouseLook>().Lock();
        GameObject instance = Instantiate(Resources.Load("UI/LoseUI") as GameObject, FindObjectOfType<Canvas>().transform);
        instance.GetComponent<CanvasGroup>().FadeIn(.8f);
    }
}
