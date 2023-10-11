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
            FindObjectOfType<PlayableDirector>().Play();
            started = true;
            OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(true, true, true);
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
