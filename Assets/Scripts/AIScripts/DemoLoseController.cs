using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            activated = true;
        }
    }
}
