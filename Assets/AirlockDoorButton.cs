using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Tween;
using UnityEngine.Events;

public class AirlockDoorButton : Interactable
{
    public Transform doorPivot;
    public bool startInteractable = true;
    public float directionalForce = -50f;
    public UnityEvent onDoorClose = new UnityEvent();

    protected override void Start()
    {
        base.Start();

        if (!startInteractable)
        {
            SetInteractable(false);
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();

        doorPivot.TweenYRot(directionalForce, 2f, () => onDoorClose.Invoke());
        SetInteractable(false);
    }
}
