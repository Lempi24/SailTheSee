using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossibleMoves : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject playerPrefab;

    public int spawnIndex;
    private void Start()
    {
        
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        spawnIndex = randomSpawnIndex;
        
        Transform randomSpawnPoint = spawnPoints[randomSpawnIndex];

       
        MovePlayer(randomSpawnPoint);
    }

    public void MovePlayer(Transform spawnPoint)
    {
        playerPrefab.transform.position = spawnPoint.position;
        playerPrefab.transform.rotation = spawnPoint.rotation;
    }
    public int GetSpawnIndex()
    {
        return spawnIndex;
    }
}
