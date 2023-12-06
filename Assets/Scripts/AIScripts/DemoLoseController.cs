using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Timers;

public class DemoLoseController : MonoBehaviour
{
    private bool activated = false;

    private void Start()
    {
        SaveManager.Instance.onReset.AddListener(() => activated = false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            GameStateController.Instance.ActivateLose();
            TimerManager.Instance.Stop(GetComponentInParent<MonsterAudio>().footstepTimer);
            activated = true;
        }
    }
}
