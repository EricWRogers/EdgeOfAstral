using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Checkpoint : MonoBehaviour
{
    public static Transform spawnpoint;
    private AIMoveState agent;
    private void Start()
    {
         agent = FindAnyObjectByType<AIMoveState>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        SaveManager.Instance.Save();
        spawnpoint = transform;

        agent.checkPoint = true;
    }

  

}
