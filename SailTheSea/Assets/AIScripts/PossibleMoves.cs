using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossibleMoves : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject playerPrefab;
    public int spawnIndex;
    
    public void MovePlayer(Transform spawnPoint)
    {
        playerPrefab.transform.position = spawnPoint.position;
        playerPrefab.transform.rotation = spawnPoint.rotation;
    }
    
}
