using System.Collections;
using System.Collections.Generic;
using OmnicatLabs.Extensions;
using OmnicatLabs.Timers;
using OmnicatLabs.Utils;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    public GameObject staminaItemPrefab;
    public int numberOfItemsToSpawn;
    public float rotationSpeed = 45f;

     
    // EXPOSING THE LISTS IN THE EDITOR CAUSES 'ObjectDisposedException' ERRORS. MAYBE I'M
    // NOT CLEARING THE LIST RIGHT. IDK.
    
    [Header("Spawn Points Variables")]
    //[SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    //[SerializeField] private List<GameObject> spawnedItems = new List<GameObject>();
    [SerializeField] public int totalSpawnPoints;
    [SerializeField] private int remainingStaminaItems;

    private List<GameObject> spawnedItems = new List<GameObject>();
    private List<Transform> spawnPoints = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        //SaveManager.Instance.onReset.AddListener(SpawnPointManager);
        //spawnPoints.Clear();

        foreach (Transform child in transform)
        {
            spawnPoints.Add(child);
        }

        totalSpawnPoints = spawnPoints.Count;
        remainingStaminaItems = numberOfItemsToSpawn;

        SpawnStaminaItems();
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> itemsToRemove = new List<GameObject>();

        foreach (GameObject item in spawnedItems)
        {
            if (item == null)
            {
                itemsToRemove.Add(item);
            }
            else
            {
                // Rotates the spawned items
                item.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
        }

        spawnedItems.RemoveAll(item => itemsToRemove.Contains(item));
        GameObject[] staminaItems = GameObject.FindGameObjectsWithTag("StaminaItem");
        remainingStaminaItems = staminaItems.Length;
    }

    void SpawnStaminaItems()
    {
        // Checks to makes sure that the number of items spawned does not exceed the number of available spawn points
        if (numberOfItemsToSpawn > totalSpawnPoints)
        {
            Debug.LogError("Error: The number of items to spawn cannot exceed the total number of spawn points avaliable.");
            
            numberOfItemsToSpawn = totalSpawnPoints;
        }

        //numberOfItemsToSpawn = Mathf.Min(numberOfItemsToSpawn, spawnPoints.Count);

        int itemsSpawned = 0;
        // Rotates the spawned item for a notiable visual effect to help the player
        Quaternion rotation = Quaternion.Euler(0f, 90f, 0f);

        while (itemsSpawned < numberOfItemsToSpawn && spawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[randomIndex];

            GameObject staminaItem = Instantiate(staminaItemPrefab, spawnPoint.position, Quaternion.identity);

            staminaItem.tag = "StaminaItem";

            spawnPoints.RemoveAt(randomIndex);

            itemsSpawned++;
            spawnedItems.Add(staminaItem);
        }
    }

    //SaveManager.Instance.onReset.AddListener(SpawnPointManager);
}
