using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public GameObject CheckPointFlag;

    private GameObject SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        //CheckPointFlag = GetComponentInChildren<Checkpoint>();
        SpawnPoint = GameObject.Find("Spawnpoint");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnPoint.transform.position = CheckPointFlag.transform.position;
        }
    }
}
