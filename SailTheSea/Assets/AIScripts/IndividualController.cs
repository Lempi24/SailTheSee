using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System.IO;



public class IndividualController : MonoBehaviour
{
    public Transform[] spawnPoints;
    private ObstacleSpawnerAI obstacleSpawner;
    private PossibleMoves possibleMoves;

    public int spawnIndex;
    private void Start()
    {
        obstacleSpawner = FindObjectOfType<ObstacleSpawnerAI>();
        possibleMoves = FindObjectOfType<PossibleMoves>();
        UpdateMove();
        ReadTextFile("PlayerCurrentIndex.txt");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            obstacleSpawner.ResetSpawner();
            UpdateMove();
        }
    }

    private void ReadTextFile(string fileName)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
            string fileContents = File.ReadAllText(filePath);
            string[] values = fileContents.Split(',');

            List<int> allValues = new List<int>();
            for (int i = 0; i < values.Length; i++)
            {
                if (int.TryParse(values[i], out int intValue))
                {
                    allValues.Add(intValue);
                }
            }

            List<int> selectedValues = new List<int>();
            for (int i = 0; i < allValues.Count; i += 4)
            {
                if (i < allValues.Count)
                {
                    selectedValues.Add(allValues[i]);
                }
            }

            Debug.Log("Selected Values:");
            foreach (int value in selectedValues)
            {
                Debug.Log(value);
            }
        }
        else
        {
            Debug.LogError("File not found at path: " + filePath);
        }
    }
    public void UpdateMove()
    {
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        spawnIndex = randomSpawnIndex;
        Debug.Log("Spawn index to: " + spawnIndex);
        Transform randomSpawnPoint = spawnPoints[randomSpawnIndex];
        possibleMoves.MovePlayer(randomSpawnPoint);
    }
}
