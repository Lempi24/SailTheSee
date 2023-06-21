using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;



public class IndividualController : MonoBehaviour
{
    public Transform[] spawnPoints;
    private ObstacleSpawnerAI obstacleSpawner;
    private PossibleMoves possibleMoves;

    private void Start()
    {
        obstacleSpawner = FindObjectOfType<ObstacleSpawnerAI>();
        possibleMoves = FindObjectOfType<PossibleMoves>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            obstacleSpawner.ResetSpawner();
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            Transform randomSpawnPoint = spawnPoints[randomSpawnIndex];
            possibleMoves.MovePlayer(randomSpawnPoint);
        }
    }
}
