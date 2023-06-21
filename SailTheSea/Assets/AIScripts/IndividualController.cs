using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class IndividualController : MonoBehaviour
{
    private ObstacleSpawnerAI obstacleSpawner;

    private void Start()
    {
        obstacleSpawner = FindObjectOfType<ObstacleSpawnerAI>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            obstacleSpawner.ResetSpawner();
        }
    }


}
