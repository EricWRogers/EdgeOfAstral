using UnityEngine;
using UnityEngine.Events;

/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/

public class Interactable : MonoBehaviour
{
    public enum InteractType
    {
        Radius,
        Interact,
        Collision,
    }
    public InteractType type;
    public float contactRadius = 3f;
    public string interactText = "to Interact";
    public string uninteractableText = "";
    public UnityEvent onInteract = new UnityEvent();
    public UnityEvent onHover = new UnityEvent();

    private Transform player;
    public bool canInteract { get; protected set; } = true;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        onInteract.AddListener(OnInteract);
        onHover.AddListener(OnHover);
    }

    void Update()
    {
        if (type == InteractType.Radius)
        {
            //Debug.Log(Vector3.Distance(player.position, transform.position));
            if (Vector3.Distance(transform.position, player.position) <= contactRadius && canInteract)
            {
                onInteract.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (type == InteractType.Collision)
        {
            if (other.CompareTag("Player") && canInteract)
            {
                onInteract.Invoke();
            }
        }
    }

    // Code for whatever each interactable needs to do
    public virtual void OnInteract()
    {
        
    }

    public void Interact()
    {
        if (canInteract)
            onInteract.Invoke();
    }

    protected virtual void OnHover()
    {

    }

    public void SetInteractable(bool value)
    {
        canInteract = value;
    }

    void OnDrawGizmosSelected()
    {
        if (type == InteractType.Radius)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, contactRadius);
        }
    }

}