using UnityEngine;
using System.Collections;
using OmnicatLabs.StatefulObject;
using OmnicatLabs.Tween;

public class LeverController : MonoBehaviour
{
    private bool isForward = false;
    private Vector3 initialPosition;
    private Vector3 forwardPosition;

    private void Start()
    {
        initialPosition = transform.position;
        forwardPosition = initialPosition + Vector3.forward * 0.1f; // Set the target position for moving the lever forward
    }

    private void OnMouseDown()
    {
        if (!isForward)
        {
            // Move the lever forward smoothly using the Tween library
            transform.TweenPosition(forwardPosition, 1.0f, () => { /* Callback function on completion, you can leave it empty or add your function here */ });
            isForward = true;
        }
        else
        {
            // Move the lever back to the initial position smoothly
            transform.TweenPosition(initialPosition, 1.0f, () => { /* Callback function on completion, you can leave it empty or add your function here */ });
            isForward = false;
        }
    }
}
