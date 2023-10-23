using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPickup : Interactable
{
    public float staminaValue = 10f;
    public override void OnInteract()
    {
        base.OnInteract();

        OmnicatLabs.CharacterControllers.CharacterController.Instance.ChangeStamina(staminaValue);
        Destroy(gameObject);
    }
}
