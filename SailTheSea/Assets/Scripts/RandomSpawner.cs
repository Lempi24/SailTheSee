using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spawnPrefabs;
    public float spawnInterval = 1f; 

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnRandomPrefab();
        }
    }

    void SpawnRandomPrefab()
    {
        int randomIndex = Random.Range(0, spawnPrefabs.Length);
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(spawnPrefabs[randomIndex], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }
}
