using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using OmnicatLabs.Audio;
using UnityEngine.Events;

public class CutsceneStart : MonoBehaviour
{
    public UnityEvent onFinish = new UnityEvent();
    private bool started = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var controller = OmnicatLabs.CharacterControllers.CharacterController.Instance;
            controller.SetControllerLocked(true, true, true);
            controller.ChangeState(OmnicatLabs.CharacterControllers.CharacterStates.Idle);
            controller.camHolder.transform.localRotation = Quaternion.identity;
            FindObjectOfType<PlayableDirector>().Play();
            started = true;
        }
    }

    private void Update()
    {
        if (FindObjectOfType<PlayableDirector>().state != PlayState.Playing && started)
        {
            OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, false, false);
            AudioManager.Instance.Play("BGM");
            onFinish.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
