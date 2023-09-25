using UnityEngine;
using System.Collections;
using OmnicatLabs.StatefulObject;
using OmnicatLabs.Tween;

public class LeverController : MonoBehaviour
{
    private bool isForward = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = Quaternion.Euler(transform.eulerAngles + Vector3.forward * 45f); // Set the target rotation for moving the lever forward
    }

    private void OnMouseDown()
    {
        if (!isForward)
        {
            // Move the lever forward smoothly using the Tween library
            transform.TweenRotation(targetRotation, 1.0f, () => { /* Callback function on completion, you can leave it empty or add your function here */ });
            isForward = true;
        }
        else
        {
            // Move the lever back to the initial rotation smoothly
            transform.TweenRotation(initialRotation, 1.0f, () => { /* Callback function on completion, you can leave it empty or add your function here */ });
            isForward = false;
        }
    }
}
