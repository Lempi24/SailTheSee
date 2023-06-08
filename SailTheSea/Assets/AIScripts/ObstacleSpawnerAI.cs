using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerAI : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spawnPrefabs;
    public float spawnInterval = 1f;
    public int spawnNumber = 5;
    private float timer = 0f;
    private float countdownTime = 0f;

    void Update()
    {
        countdownTime += Time.deltaTime;
        timer += Time.deltaTime;

        if (countdownTime > 6f)
        {
            if (timer >= spawnInterval)
            {
                timer = 0f;
                SpawnRandomPrefabs(spawnNumber);
            }
        }
    }

    void SpawnRandomPrefabs(int count)
    {
        List<int> availableSpawnIndexes = new List<int>();

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            availableSpawnIndexes.Add(i);
        }

        for (int i = 0; i < count; i++)
        {
            if (availableSpawnIndexes.Count == 0)
                break;

            int randomIndex = Random.Range(0, availableSpawnIndexes.Count);
            int spawnIndex = availableSpawnIndexes[randomIndex];
            availableSpawnIndexes.RemoveAt(randomIndex);

            Instantiate(spawnPrefabs[i], spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }
}
