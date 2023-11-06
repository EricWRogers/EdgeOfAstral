using UnityEngine;
using UnityEngine.Events;
using OmnicatLabs.Tween;
using OmnicatLabs.Audio;

public class MotionScanner : MonoBehaviour
{
    GameObject player;
    public Transform doorPivot;
    public float openAngle = -50f;
    public float timeToOpen = 5f;
    public UnityEvent onDoorClose = new UnityEvent();
    public UnityEvent onDoorOpen = new UnityEvent();
    public AirlockDoorButton buttonForThisDoor;
    public AirlockDoorButton buttonForOtherDoor;
    public bool doorOpening = false;
    public bool doorClosed = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //onDoorOpen.AddListener(DoorOpen);
        onDoorClose.AddListener(DoorClose);
    }

    private void OnTriggerEnter(Collider collider)
    {
        //If the player is within the collider, open the door
        if (collider.CompareTag("Player") && !doorOpening)
        {
            //OmniTween.CancelTween(doorPivot);
            doorPivot.TweenYRot(openAngle, timeToOpen, () => onDoorOpen.Invoke());
            doorOpening = true;
            doorClosed = false;
            buttonForOtherDoor.SetInteractable(false);
            buttonForThisDoor.SetInteractable(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        //OmniTween.CancelTween(doorPivot);
        doorPivot.TweenYRot(-openAngle, timeToOpen, () => onDoorClose.Invoke());
    }

    void DoorOpen()
    {
        doorPivot.TweenYRot(-openAngle, 2f, () => onDoorClose.Invoke());
    }

    void DoorClose()
    {
        doorClosed = true;
        doorOpening = false;
        buttonForOtherDoor.SetInteractable(true);
        buttonForThisDoor.SetInteractable(true);
    }
}
