using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Tween;
using UnityEngine.Events;

public class DoorSensor : MonoBehaviour
{
    public Transform doorPivot;
    public float directionalForce = -50f;
    public UnityEvent onDoorClose = new UnityEvent();
    public bool isOpen = false;
    public DoorSensor otherSensor;
    private bool canInteract = true;

    private void Start()
    {
        onDoorClose.AddListener(() => canInteract = true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isOpen && !otherSensor.isOpen && canInteract)
            {
                isOpen = false;
                doorPivot.TweenYRot(-directionalForce, 2f, () => onDoorClose.Invoke());
            }
            else
            {   
                if (canInteract)
                {
                    isOpen = true;
                    doorPivot.TweenYRot(directionalForce, 2f, () => onDoorClose.Invoke());
                }
                    
            }
        }
    }
}
