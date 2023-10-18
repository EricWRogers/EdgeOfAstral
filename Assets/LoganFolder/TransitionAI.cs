using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TransitionAI : MonoBehaviour
{
    public Transform exitTrans;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Crossed");
            // GameObject temp = GetComponentInParent<NavMeshAgent>().gameObject;
            GameObject temp = FindAnyObjectByType<NavMeshAgent>().gameObject;
            temp.SetActive(false);
            temp.transform.position = exitTrans.position;
            temp.SetActive(true);
            temp.GetComponentInChildren<AIMoveState>().checkPoint = false;
        }
    }
}
