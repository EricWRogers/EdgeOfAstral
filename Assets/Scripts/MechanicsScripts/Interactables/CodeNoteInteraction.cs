using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeNoteInteraction : Interactable
{
    protected override void OnHover()
    {
        base.OnHover();

        GetComponent<Dialogue>().TriggerDialogue();
    }
}
