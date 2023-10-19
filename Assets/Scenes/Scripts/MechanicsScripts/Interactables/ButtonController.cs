using UnityEngine;
using System.Collections;
using OmnicatLabs.StatefulObject;
using OmnicatLabs.Tween;

public class ButtonController : MonoBehaviour
{
    private bool isPressed = false;
    private Vector3 initialPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + Vector3.down * 0.1f; // Set the target position for the button down movement
    }

    private void OnMouseDown()
    {
        if (!isPressed)
        {
            // Move the button down smoothly using the Tween library
            transform.TweenPosition(targetPosition, 1.0f, () => { /* Callback function on completion, you can leave it empty or add your function here */ });
            isPressed = true;
        }
        else
        {
            // Move the button back up smoothly to the initial position
            transform.TweenPosition(initialPosition, 1.0f, () => { /* Callback function on completion, you can leave it empty or add your function here */ });
            isPressed = false;
        }
    }
}
