using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossibleMoves : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject playerPrefab;

    private void Start()
    {
        
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);

        
        Transform randomSpawnPoint = spawnPoints[randomSpawnIndex];

       
        MovePlayer(randomSpawnPoint);
    }

    private void MovePlayer(Transform spawnPoint)
    {
        playerPrefab.transform.position = spawnPoint.position;
        playerPrefab.transform.rotation = spawnPoint.rotation;
    }
}
