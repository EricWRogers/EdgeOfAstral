using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();
    public int spawnIndex = 0;

    private void Start()
    {
        OmnicatLabs.CharacterControllers.CharacterController.Instance.transform.position = spawnPoints[spawnIndex].position;
    }
}
