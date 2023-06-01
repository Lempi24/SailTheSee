using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spawnPrefabs;
    public float spawnInterval = 1f;
    public int spawnNumber = 5;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && spawnPoints.Length >= 3)
        {
            timer = 0f;
            SpawnRandomPrefabs(spawnNumber);
        }
    }

    void SpawnRandomPrefabs(int count)
    {
        
        List<int> availableSpawnIndexes = new List<int>();

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            availableSpawnIndexes.Add(i);
        }

        List<int> spawnIndexes = new List<int>();

        while (spawnIndexes.Count < count && availableSpawnIndexes.Count > 0)
        {
            int randomIndex = Random.Range(0, availableSpawnIndexes.Count);
            int spawnIndex = availableSpawnIndexes[randomIndex];
            availableSpawnIndexes.RemoveAt(randomIndex);

            spawnIndexes.Add(spawnIndex);
            Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Length)], spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }
}
