using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerAI : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject objectToSpawn;
    public int[] spawnIndexes = { 1, 8, 2, 13, 11, 6, 13, 3, 9, 4, 12, 7, 5, 10, 13, 6, 11, 8, 1, 13, 2, 12, 9, 3, 10, 4, 7, 5, 11, 14, 1, 6, 12, 3, 9, 13, 2, 10, 7, 4, 8, 5, 13, 2, 6, 11, 9, 3, 12, 7, 10 };

    private int spawnIndex;
    private bool resetSpawner;
    private void Start()
    {
        spawnIndex = 0;
        resetSpawner = false;
        InvokeRepeating("SpawnObjects", 0f, 3f);
    }

    public void ResetSpawner()
    {
        spawnIndex = 0;
        resetSpawner = false;
        GameObject[] spawnedObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject spawnedObject in spawnedObjects)
        {
            if (spawnedObject.name == objectToSpawn.name + "(Clone)")
            {
                Destroy(spawnedObject);
            }
        }
    }

    private void SpawnObjects()
    {
        if (spawnIndex >= spawnIndexes.Length)
        {
            spawnIndex = 0;
        }

        int objectsToSpawn = Mathf.Min(8, spawnIndexes.Length - spawnIndex);

        for (int i = 0; i < objectsToSpawn; i++)
        {
            int currentIndex = spawnIndex + i;
            int spawnPointIndex = spawnIndexes[currentIndex];

            if (spawnPointIndex >= 0 && spawnPointIndex < spawnPoints.Length)
            {
                Instantiate(objectToSpawn, spawnPoints[spawnPointIndex].position, Quaternion.identity);
            }
        }

        spawnIndex += objectsToSpawn;
    }

    public void TriggerSpawnerReset()
    {
        resetSpawner = true;
    }


}
