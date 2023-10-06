using UnityEngine;
using UnityEngine.SceneManagement;
using OmnicatLabs.Tween;
public class PlayerGreetPopUp : MonoBehaviour
{
    public static bool GreetMessageIsActive = false;
    public float fadeTime = .3f;
    public UITextState playerGreetPopUp;
    public UIStateMachineController controller;

    public void Resume()
    {

    }
}
