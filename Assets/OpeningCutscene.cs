using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpeningCutscene : MonoBehaviour
{
    public CameraShakeController shaker;

    private void Start()
    {
        OmnicatLabs.CharacterControllers.CharacterController.Instance.GetComponent<PlayerInput>().enabled = false;
        shaker.CauseShake();
        shaker.onShakeFinish.AddListener(() => OmnicatLabs.CharacterControllers.CharacterController.Instance.GetComponent<PlayerInput>().enabled = true);
    }
}
