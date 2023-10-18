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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isOpen == true)
            {
                isOpen = false;
                doorPivot.TweenYRot(-directionalForce, 2f, () => onDoorClose.Invoke());
            }
            else
            {
                isOpen = true;
                doorPivot.TweenYRot(directionalForce, 2f, () => onDoorClose.Invoke());
            }
        }
    }
}
