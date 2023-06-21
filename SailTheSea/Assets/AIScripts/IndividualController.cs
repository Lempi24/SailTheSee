using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;



public class IndividualController : MonoBehaviour
{
    public Transform[] spawnPoints;
    private ObstacleSpawnerAI obstacleSpawner;
    private PossibleMoves possibleMoves;
    private Raycast raycast;

    public int spawnIndex;
    public List<int> allValues = new List<int>();
    private List<int> selectedValues = new List<int>();
    private int selectedIndex = 0;
    public int selectedIndexRay = 0;
    private int help = 0;

    private void Start()
    {
        ReadTextFile("PlayerCurrentIndex.txt");
        obstacleSpawner = FindObjectOfType<ObstacleSpawnerAI>();
        possibleMoves = FindObjectOfType<PossibleMoves>();
        raycast = FindObjectOfType<Raycast>();
        UpdateMove();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            obstacleSpawner.ResetSpawner();
            ReadTextFile("PlayerCurrentIndex.txt");
            selectedIndex = 0;
            selectedIndexRay = 0;
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

            allValues.Clear();
            selectedValues.Clear();

            foreach (string value in values)
            {
                if (int.TryParse(value, out int intValue))
                {
                    allValues.Add(intValue);
                }
            }

            for (int i = 0; i < allValues.Count; i += 4)
            {
                if (i < allValues.Count)
                {
                    selectedValues.Add(allValues[i]);
                }
            }
        }
        else
        {
            Debug.LogError("File not found at path: " + filePath);
        }
    }

    public void UpdateMove()
    {

        if (selectedIndex < selectedValues.Count)
        {
            int value = selectedValues[selectedIndex];
            spawnIndex = value;
            Transform ValueV = spawnPoints[value];
            selectedIndex++;
            possibleMoves.MovePlayer(ValueV);
        }
        else
        {
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            spawnIndex = randomSpawnIndex;
            Debug.Log("Spawn index to: " + spawnIndex);
            Transform randomSpawnPoint = spawnPoints[randomSpawnIndex];
            selectedIndex++;
            possibleMoves.MovePlayer(randomSpawnPoint);
        }

        CancelInvoke();
    }
}

