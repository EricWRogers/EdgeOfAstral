using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Interactable
{
    protected override void OnHover()
    {
        base.OnHover();

        GetComponent<Dialogue>().TriggerDialogue();
    }

    public override void OnInteract()
    {
        base.OnInteract();

        Destroy(gameObject);
    }
}
