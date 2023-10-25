using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OmnicatLabs.Audio;

public class OpeningCutscene : MonoBehaviour
{
    public CameraShakeController shaker;
    public TutorialTextTrigger firstTutorial;
    public CanvasGroup staminaUI;

    public void StartCutscene()
    {
        OmnicatLabs.CharacterControllers.CharacterController.Instance.GetComponent<PlayerInput>().enabled = false;
        shaker.CauseShake();
        AudioManager.Instance.Play("OpeningExplosion");
        firstTutorial.GetComponent<Collider>().enabled = true;
        staminaUI.alpha = 1f;
        shaker.onShakeFinish.AddListener(() => OmnicatLabs.CharacterControllers.CharacterController.Instance.GetComponent<PlayerInput>().enabled = true);

    }
}
