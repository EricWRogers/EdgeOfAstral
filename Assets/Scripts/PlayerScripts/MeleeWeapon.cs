using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    Animator animator;

    [Header("Weapon Variables")]
    [SerializeField]
    private BoxCollider weaponBoxCollider;
    [SerializeField]
    public string[] validTags;

    public GameObject enemy;
    public GameObject weapon;

    [Header("Attack Variables")]
    public float attackCoolDown;
    public float attackDamage;

    [HideInInspector]
    public bool canAttack = true;
    public bool isAttacking = false;

    [Header("Gizmo Variables")]
    public Color gizmoColor = Color.red;    // Color of raycast on screen
    public float gizomoDuration = 0.3f;     // Duration in seconds to display gizmos
     public float gizmoBladeLength = 0.2f;
    private bool canPerformRaycasts;

    private void Start()
    {  
        if (enemy == null)
        {
            enemy = GameObject.FindWithTag("Enemy");
        }

        if (weapon == null)
        {
            weapon = GameObject.FindWithTag("Weapon");
        }

        if (weaponBoxCollider == null)
        {
            weaponBoxCollider = gameObject.GetComponent<BoxCollider>();
        }

        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        PerformMeleeAttack();
    }

    public void PerformMeleeAttack()
    {
        if (Input.GetMouseButtonDown(0) && canAttack) //&& !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attacking");
            Debug.Log("Player is Attacking!");
            canAttack = false;
            StartCoroutine(AttackCoolDown());
        }

        else if (!canAttack)
        {
            isAttacking = false;
            //DisableWeaponCollider();
        }
    }

    public void EnableWeaponCollider()
    {
        weaponBoxCollider.enabled = true;
    }

    public void DisableWeaponCollider()
    {
        weaponBoxCollider.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy has been hit");
            Destroy(other.gameObject);
        }
    }

    private IEnumerator AttackCoolDown()
    {
        Debug.Log("Attack Cooldown!");
        
        yield return new WaitForSeconds(attackCoolDown);
        
        canAttack = true;
    }

    private bool IsAttacking()
    {
        bool isAttacking = animator.GetCurrentAnimatorStateInfo(0).IsName("Attacking");
        Debug.Log("IsAttacking: " + isAttacking);
        return isAttacking;
    }
    

    /*
    public RaycastHit PerformRaycasts()
    {
        RaycastHit hitResult = new RaycastHit();

        foreach (Transform hitPoint in hitPoints)
        {
            Ray ray = new Ray(hitPoint.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, rayCastDistance, hitLayers))
            {
                hitResult = hit;

                Debug.Log("Raycast has hit " + hit.collider.gameObject.name + " !");

                Debug.DrawRay(ray.origin, ray.direction * rayCastDistance, Color.green);

                break;
            }

            else
            {
                Debug.DrawRay(ray.origin, ray.direction * rayCastDistance, Color.red);
            }
        }

        return hitResult;
    }
    */

    /*
    public void DrawTrajectory()
    {
        if (canPerformRaycasts)
        {
            foreach (Transform hitPoint in hitPoints)
            {
                Vector3 bladeEnd = hitPoint.position + hitPoint.forward * gizmoBladeLength;

                Debug.DrawLine(hitPoint.position, bladeEnd, gizmoColor, gizomoDuration);
            }
        }
    }
    */

    
    // Allows viewing of gizmos when game is in play mode
    /*private void OnDrawGizmosSelected()
    {
        if (Application.isPlaying && gizomoDuration > 0f)
        {
            Gizmos.color = gizmoColor;
            
            foreach (Transform hitPoint in hitPoints)
            {
                //Gizmos.DrawSphere(hitPoint.position, 0.1f);

                Vector3 bladeStart = hitPoint.position - hitPoint.forward * gizmoBladeLength;
            }
        }
    }
    */

    // Allows viewing of gizmos during editing
    /*
    private void OnDrawGizmos()
    {
        if (canPerformRaycasts && gizomoDuration > 0f)
        {
            Gizmos.color = gizmoColor;

            foreach (Transform hitPoint in hitPoints)
            {
                //Gizmos.DrawSphere(hitPoint.position, 0.1f);

                Vector3 bladeEnd = hitPoint.position - hitPoint.forward * gizmoBladeLength;

                Gizmos.DrawLine(hitPoint.position, bladeEnd);
            }
        }
    } 
    */
}
