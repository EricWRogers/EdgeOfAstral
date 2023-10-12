using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAI : MonoBehaviour
{
    public Transform exitTrans;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Crossed");

            other.transform.position = exitTrans.position;
        }
    }
}
