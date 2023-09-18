using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoDoor : Interactable
{
    public string keyName;

    public override void OnInteract()
    {
        base.OnInteract();

        if (InventorySystem.Instance.Get(keyName) != null)
        {
            GameStateController.ActivateWin();
        }
    }
}
