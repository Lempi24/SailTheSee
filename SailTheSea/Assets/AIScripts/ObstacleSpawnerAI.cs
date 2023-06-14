using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerAI : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject objectToSpawn;
    public int[] spawnIndexes = { 1, 8, 2, 14, 11, 6, 13, 3, 9, 4, 12, 7, 5, 10, 13, 6, 11, 8, 1, 14, 2, 12, 9, 3, 10, 4, 7, 5, 11, 14, 1, 6, 12, 3, 9, 13, 2, 10, 7, 4, 8, 5, 14, 2, 6, 11, 9, 3, 12, 7, 10 };

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

        for (int i = 0; i < 5; i++)
        {
            int currentIndex = spawnIndex + i;

            if (currentIndex >= spawnIndexes.Length)
            {
                break;
            }

            if (spawnIndexes[currentIndex] >= spawnPoints.Length)
            {
                continue;
            }

            Instantiate(objectToSpawn, spawnPoints[spawnIndexes[currentIndex]].position, Quaternion.identity);
        }

        spawnIndex += 5;
    }

    public void TriggerSpawnerReset()
    {
        resetSpawner = true;
    }
}
