using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneticAlgorithm : MonoBehaviour
{
    public GameObject PlayerAI;
    public GameObject obstacleSpawner;

    public int populationSize = 50;
    public int maxGenerations = 15;
    private int currentGeneration = 0;
    public int GenerationCount = 0;

    private List<GameObject> population;
    public TMP_Text generationText;

    void Start()
    {
        GenerationCount = populationSize;
        //Spawn AI na podstawie wielkosci populacji
        population = new List<GameObject>();

        for (int i = 0; i < populationSize; i++)
        {
            GameObject newPlayerAI = Instantiate(PlayerAI, PlayerAI.transform.position, Quaternion.identity);
            population.Add(newPlayerAI);
        }
    }

    void Update()
    {
        //Sprawdza czy jest taki ktos jak Player
        PlayerAI = GameObject.FindGameObjectWithTag("Player");
        //Jesli jest taki ktos z tagiem player to rob to:
        if (PlayerAI.scene.IsValid() == true) 
        {
            //Jesli liczba populacji jest rowna 2
            if (GenerationCount <= 2)
            { 
                population = new List<GameObject>();

                for (int i = 0; i < populationSize; i++)
                {
                    GameObject newPlayer = Instantiate(PlayerAI, PlayerAI.transform.position, Quaternion.identity);
                    population.Add(newPlayer);
                }
                currentGeneration++;
            }
        }
        UpdateGenerationText();
    }

    //Wyswietlanie numeru Generacji
    void UpdateGenerationText()
    {
        generationText.text = "Generation: " + currentGeneration.ToString() + "Count: " + GenerationCount.ToString();
    }
}

//
//GenerationCount = maxGenerations;
//Spawn AI
//population = new List<GameObject>();

//for (int i = 0; i < populationSize; i++)
//{
//    GameObject newPlayer = Instantiate(player, player.transform.position, Quaternion.identity);
//    population.Add(newPlayer);
//}

//UpdateGenerationText();