using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm : MonoBehaviour
{
    public GameObject player; // Referencja do obiektu gracza
    public GameObject obstacleSpawner; // Referencja do obiektu generuj¹cego przeszkody

    public int populationSize = 50; // Rozmiar populacji
    public int maxGenerations = 15; // Maksymalna liczba generacji

    private List<GameObject> population; // Aktualna populacja
    private int currentGeneration = 0; // Aktualna generacja

    void Start()
    {
        population = new List<GameObject>();

        // Tworzenie populacji pocz¹tkowej
        for (int i = 0; i < populationSize; i++)
        {
            GameObject newPlayer = Instantiate(player, transform.position, Quaternion.identity);
            population.Add(newPlayer);
        }

        StartCoroutine(EvolutionLoop());
    }

    IEnumerator EvolutionLoop()
    {
        while (currentGeneration < maxGenerations)
        {
            // Ocena populacji
            EvaluatePopulation();

            // Selekcja
            List<GameObject> selectedParents = Selection();

            // Krzy¿owanie
            List<GameObject> offspring = Crossover(selectedParents);

            // Mutacja
            Mutate(offspring);

            // Zast¹pienie populacji potomnej
            ReplacePopulation(offspring);

            currentGeneration++;
            yield return null;
        }

        // Zakoñczenie algorytmu - osi¹gniêto maksymaln¹ liczbê generacji
        // Tutaj mo¿esz przeprowadziæ dodatkow¹ analizê wyników lub zastosowaæ inne dzia³ania koñcowe.
    }

    void EvaluatePopulation()
    {
        foreach (GameObject individual in population)
        {
            // Obliczanie czasu prze¿ycia dla ka¿dego osobnika w populacji
            float survivalTime = individual.GetComponent<IndividualController>().GetSurvivalTime();

            // Ocena na podstawie czasu prze¿ycia
            individual.GetComponent<IndividualController>().SetFitness(survivalTime);
        }
    }

    List<GameObject> Selection()
    {
        // Wybierz najlepsze osobniki na podstawie oceny (rankingowa selekcja)
        population.Sort((x, y) => y.GetComponent<IndividualController>().GetFitness().CompareTo(x.GetComponent<IndividualController>().GetFitness()));

        // Wybierz 50% najlepszych osobników jako rodziców
        int selectionSize = Mathf.RoundToInt(populationSize * 0.5f);
        List<GameObject> selectedParents = population.GetRange(0, selectionSize);

        return selectedParents;
    }

    List<GameObject> Crossover(List<GameObject> parents)
    {
        List<GameObject> offspring = new List<GameObject>();

        while (offspring.Count < populationSize)
        {
            // Losowe wybieranie dwóch rodziców
            int parentIndex1 = Random.Range(0, parents.Count);
            int parentIndex2 = Random.Range(0, parents.Count);

            GameObject parent1 = parents[parentIndex1];
            GameObject parent2 = parents[parentIndex2];

            // Tworzenie potomstwa poprzez krzy¿owanie strategii rodziców
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
            // Losowe mutacje w strategii potomka
            child.GetComponent<IndividualController>().MutateStrategy();
        }
    }

    void ReplacePopulation(List<GameObject> offspring)
    {
        // Usuniêcie poprzedniej populacji
        foreach (GameObject individual in population)
        {
            Destroy(individual);
        }
        population.Clear();

        // Dodanie nowej populacji
        population.AddRange(offspring);
    }
}
