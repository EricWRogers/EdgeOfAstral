using UnityEngine;
using OmnicatLabs.Tween;
using UnityEngine.Events;
using OmnicatLabs.Timers;
using OmnicatLabs.Audio;

public class AirlockDoorButton : Interactable
{
    public Transform doorPivot;
    public bool startInteractable = true;
    public float directionalForce = -50f;
    public UnityEvent onDoorClose = new UnityEvent();
    public UnityEvent onDoorOpen = new UnityEvent();
    public AirlockDoorButton buttonForOtherDoor;
    public MotionScanner doorToOpen;
    public MotionScanner doorBehind;

    protected override void Start()
    {
        base.Start();

        if (!startInteractable)
        {
            SetInteractable(false);
        }

        onDoorOpen.AddListener(DoorOpen);
        onDoorClose.AddListener(DoorClose);
    }

    public override void OnInteract()
    {
        base.OnInteract();

        if (doorToOpen.doorClosed && doorBehind.doorClosed)
        {
            doorPivot.TweenYRot(directionalForce, 2f, () => onDoorOpen.Invoke());
            doorToOpen.doorOpening = true;
            doorToOpen.doorClosed = false;
            SetInteractable(false);
        }
    }

    void DoorOpen()
    {
        doorPivot.TweenYRot(-directionalForce, 2f, () => onDoorClose.Invoke());
    }

    void DoorClose()
    {
        doorToOpen.doorClosed = true;
        doorToOpen.doorOpening = false;
        SetInteractable(true);
        buttonForOtherDoor.SetInteractable(true);
    }
}
