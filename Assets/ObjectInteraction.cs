using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("This is interactable UI text that you can edit with tweening.")]
    public TextMeshProUGUI interactText;

    [SerializeField]
    [Tooltip("This is the keybind for object interaction. You can change this here.")]
    private KeyCode interactKey = KeyCode.E;

    [SerializeField]
    [Tooltip("This is where you add the camera you want the raycast to fire from.")]
    private Camera camera;

    public float interactRange;
    public LayerMask interactableLayer;
    //Ray RayOrigin;
    //RaycastHit HitInfo;


    void Start()
    {
        SetInteractTextVisibility(false);
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactableLayer))
        {
            Interactable interactableObject = hit.collider.GetComponent<Interactable>();

            if (interactableObject != null)
            {
                // Display interaction info. I.E. Tween things go here.
                //Debug.Log("Raycast has hit interactable object");
                Debug.DrawLine(ray.origin, hit.point, Color.red);

                //***Uncomment this and and the interactable/ tweened text you want to use and it should work just fine * **
                interactText.text = "Press E to Interact";

                interactText.enabled = true;


                if (Input.GetKeyDown(interactKey))
                {
                    interactableObject.onInteract.Invoke();
                }
            }
        }
        else
        {
            // Hides the interaction text when not looking, or in range of the object
           SetInteractTextVisibility(false);
        }
    }

    public void SetInteractTextVisibility(bool isVisable)
    {
        if (interactText != null)
        {
            interactText.enabled = isVisable;
        }
    }
}
