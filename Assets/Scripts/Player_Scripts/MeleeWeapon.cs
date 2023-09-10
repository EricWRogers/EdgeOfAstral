using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public Color gizmoColor = Color.red;    // Color of raycast on screen
    public float gizomoDuration = 0.3f;     // Duration in seconds to display gizmos
    private bool canPerformRaycasts = true;

    [Header("Weapon Variables")]
    public Transform[] hitPoints;
    public LayerMask hitLayers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PerformRaycasts();
        }
    }

    // Creates and checks for raycast interaction in specified layers and then applies damage
    // through references to a separate enemy or damage script.
    private void PerformRaycasts()
    {
        foreach (Transform hitPoint in hitPoints)
        {
            Ray ray = new Ray(hitPoint.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, hitLayers))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    //hit.collider.GetComponent<EnemyScript>().TakeDamage(10); // Set damage numbers and script name in separate enemy script
                }
            }
        }
    }

    public void EnableHitDetection()
    {
        canPerformRaycasts = true;
    }

    public void DisableHitDetection()
    {
        canPerformRaycasts = false;
    }

    // Allows viewing of gizmos when game is in play mode
    private void OnDrawGizmosSelected()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = gizmoColor;
            
            foreach (Transform hitPoint in hitPoints)
            {
                Gizmos.DrawSphere(hitPoint.position, 0.1f);
            }
        }
    }

    // Allows viewing of gizmos during editing
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying && gizomoDuration > 0f)
        {
            Gizmos.color = gizmoColor;

            foreach (Transform hitPoint in hitPoints)
            {
                Gizmos.DrawSphere(hitPoint.position, 0.1f);
            }
        }
    }
}
