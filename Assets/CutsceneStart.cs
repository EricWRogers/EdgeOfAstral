using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneStart : MonoBehaviour
{
    private bool started = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var controller = OmnicatLabs.CharacterControllers.CharacterController.Instance;
            controller.SetControllerLocked(true, true, true);
            controller.ChangeState(OmnicatLabs.CharacterControllers.CharacterStates.Idle);
            FindObjectOfType<PlayableDirector>().Play();
            started = true;
        }
    }

    private void Update()
    {
        if (FindObjectOfType<PlayableDirector>().state != PlayState.Playing && started)
        {
            OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, false, false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
