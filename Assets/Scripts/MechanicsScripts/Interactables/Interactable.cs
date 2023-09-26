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
    public UnityEvent onInteract = new UnityEvent();

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        onInteract.AddListener(OnInteract);
    }

    void Update()
    {
        if (type == InteractType.Radius)
        {
            //Debug.Log(Vector3.Distance(player.position, transform.position));
            if (Vector3.Distance(transform.position, player.position) <= contactRadius)
            {
                onInteract.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (type == InteractType.Collision)
        {
            if (other.CompareTag("Player"))
            {
                onInteract.Invoke();
            }
        }
    }

    // Code for whatever each interactable needs to do
    public virtual void OnInteract()
    {
        
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