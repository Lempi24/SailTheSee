using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spawnPrefabs;
    public float spawnInterval = 2f;
    public int spawnNumber = 5;
    private float timer = 0f;
    private float CountdownTime = 0f;
    private float period = 0f;

    void Update()
    {
        CountdownTime += Time.deltaTime;
        timer += Time.deltaTime;

        if (CountdownTime > 6f)
        {
            if (timer >= spawnInterval && spawnPoints.Length >= 3)
            {
                timer = 0f;
                SpawnRandomPrefabs(spawnNumber);
            }
        }
        if(spawnInterval < 0.5f)
        {
            spawnInterval = 0.5f;
        }
        if (period > 10f)
        {
            spawnInterval -= 0.1f;
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
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
