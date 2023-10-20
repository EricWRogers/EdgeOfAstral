using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeNoteInteraction : Interactable
{
    public void StartTracking()
    {
        SaveManager.Instance.Track(this);
    }

    protected override void OnHover()
    {
        base.OnHover();

        GetComponent<Dialogue>().TriggerDialogue();
    }

    public override void OnReset()
    {
        base.OnReset();

        GetComponent<RandNumGen>().Generate();
    }
}
