using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneticAlgorithm : MonoBehaviour
{
    public GameObject player;
    public GameObject obstacleSpawner;

    public int populationSize = 50;
    public int maxGenerations = 15;

    private List<GameObject> population;
    private int currentGeneration = 0;

    public TMP_Text generationText;

    void Start()
    {
        //Spawn AI
        population = new List<GameObject>();

        for (int i = 0; i < populationSize; i++)
        {
            GameObject newPlayer = Instantiate(player, player.transform.position, Quaternion.identity);
            population.Add(newPlayer);
        }

        UpdateGenerationText();
    }

    void Update()
    {
        
    }

    void UpdateGenerationText()
    {
        generationText.text = "Generation: " + currentGeneration.ToString();
    }
}
