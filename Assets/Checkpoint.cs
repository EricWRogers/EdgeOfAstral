using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Checkpoint : MonoBehaviour
{
    public static Transform spawnpoint;
   
    private void OnTriggerEnter(Collider other)
    {
        
        SaveManager.Instance.Save();
        spawnpoint = transform;

        
    }

  

}
