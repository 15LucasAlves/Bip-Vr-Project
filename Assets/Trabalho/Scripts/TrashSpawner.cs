using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs; // Trash prefabs
    //public Transform spawnArea; // Spawn area
    public MeshCollider meshcollider;
    public int spawnAmount = 10; // Number of items to spawn

    public float limitsControls;
     public float limitHeight;

    void Start()
    {
        SpawnTrash();
    }

    void SpawnTrash()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            GameObject randomTrash = trashPrefabs[Random.Range(0, trashPrefabs.Length)];
            Instantiate(randomTrash, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        // Get the bounds of the MeshCollider
        Bounds bounds =  meshcollider.bounds;

        // Generate a random position within the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x-limitsControls);
        float y = Random.Range(bounds.min.y+limitHeight, bounds.max.y+limitHeight);
        float z = Random.Range(bounds.min.z, bounds.max.z-limitsControls);

        Vector3 randomPosition = new Vector3(x, y, z);

  return randomPosition;
        // Ensure the position is inside the MeshCollider
        if (meshcollider.bounds.Contains(randomPosition))
        {
            return randomPosition;
        }
        else
        {
            // If not, recursively call the method until a valid position is found
            return GetRandomPosition();
        }
    }
}