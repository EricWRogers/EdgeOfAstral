using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : Interactable
{
    public override void OnInteract()
    {
        base.OnInteract();

        GameStateController.Instance.ActivateWin();
    }
}
