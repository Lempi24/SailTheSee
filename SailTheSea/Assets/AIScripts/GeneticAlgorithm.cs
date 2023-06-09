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
        population = new List<GameObject>();

        
        for (int i = 0; i < populationSize; i++)
        {
            GameObject newPlayer = Instantiate(player, player.transform.position, Quaternion.identity);
            population.Add(newPlayer);
        }

        StartCoroutine(EvolutionLoop());

        UpdateGenerationText();

    }

    IEnumerator EvolutionLoop()
    {
        while (currentGeneration < maxGenerations)
        {
           
            EvaluatePopulation();

           
            List<GameObject> selectedParents = Selection();

           
            List<GameObject> offspring = Crossover(selectedParents);

           
            Mutate(offspring);

           
            ReplacePopulation(offspring);

            currentGeneration++;
            yield return null;
        }

        
    }

    void EvaluatePopulation()
    {
        foreach (GameObject individual in population)
        {
           
            float survivalTime = individual.GetComponent<IndividualController>().GetSurvivalTime();

            individual.GetComponent<IndividualController>().SetFitness(survivalTime);
        }
    }

    List<GameObject> Selection()
    {
        
        population.Sort((x, y) => y.GetComponent<IndividualController>().GetFitness().CompareTo(x.GetComponent<IndividualController>().GetFitness()));

       
        int selectionSize = Mathf.RoundToInt(populationSize * 0.5f);
        List<GameObject> selectedParents = population.GetRange(0, selectionSize);

        return selectedParents;
    }

    List<GameObject> Crossover(List<GameObject> parents)
    {
        List<GameObject> offspring = new List<GameObject>();

        while (offspring.Count < populationSize)
        {
         
            int parentIndex1 = Random.Range(0, parents.Count);
            int parentIndex2 = Random.Range(0, parents.Count);

            GameObject parent1 = parents[parentIndex1];
            GameObject parent2 = parents[parentIndex2];

          
            GameObject child = Instantiate(player, transform.position, Quaternion.identity);
            child.GetComponent<IndividualController>().CombineStrategies(parent1, parent2);

            offspring.Add(child);
        }

        return offspring;
    }

    void Mutate(List<GameObject> offspring)
    {
        foreach (GameObject child in offspring)
        {
            
            child.GetComponent<IndividualController>().MutateStrategy();
        }
    }

    void ReplacePopulation(List<GameObject> offspring)
    {
        
        foreach (GameObject individual in population)
        {
            Destroy(individual);
        }
        population.Clear();

       
        population.AddRange(offspring);
    }
    void UpdateGenerationText()
    {
        
        generationText.text = "Generation: " + currentGeneration.ToString();
    }
}
