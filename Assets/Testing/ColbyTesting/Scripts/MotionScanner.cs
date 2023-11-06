using UnityEngine;
using UnityEngine.Events;
using OmnicatLabs.Tween;
using OmnicatLabs.Audio;

public class MotionScanner : MonoBehaviour
{
    GameObject player;
    public Transform doorPivot;
    public float directionalForce = -50f;
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
            Debug.Log("Found");
            doorPivot.TweenYRot(directionalForce, 2f, () => onDoorOpen.Invoke());
            doorOpening = true;
            doorClosed = false;
            buttonForOtherDoor.SetInteractable(false);
            buttonForThisDoor.SetInteractable(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorPivot.TweenYRot(-directionalForce, 2f, () => onDoorClose.Invoke());
    }

    void DoorOpen()
    {
        doorPivot.TweenYRot(-directionalForce, 2f, () => onDoorClose.Invoke());
    }

    void DoorClose()
    {
        doorClosed = true;
        doorOpening = false;
        buttonForOtherDoor.SetInteractable(true);
        buttonForThisDoor.SetInteractable(true);
    }
}
