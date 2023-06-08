using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm : MonoBehaviour
{
    public GameObject player; // Referencja do obiektu gracza
    public GameObject obstacleSpawner; // Referencja do obiektu generuj�cego przeszkody

    public int populationSize = 50; // Rozmiar populacji
    public int maxGenerations = 15; // Maksymalna liczba generacji

    private List<GameObject> population; // Aktualna populacja
    private int currentGeneration = 0; // Aktualna generacja

    void Start()
    {
        population = new List<GameObject>();

        // Tworzenie populacji pocz�tkowej
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

            // Krzy�owanie
            List<GameObject> offspring = Crossover(selectedParents);

            // Mutacja
            Mutate(offspring);

            // Zast�pienie populacji potomnej
            ReplacePopulation(offspring);

            currentGeneration++;
            yield return null;
        }

        // Zako�czenie algorytmu - osi�gni�to maksymaln� liczb� generacji
        // Tutaj mo�esz przeprowadzi� dodatkow� analiz� wynik�w lub zastosowa� inne dzia�ania ko�cowe.
    }

    void EvaluatePopulation()
    {
        foreach (GameObject individual in population)
        {
            // Obliczanie czasu prze�ycia dla ka�dego osobnika w populacji
            float survivalTime = individual.GetComponent<IndividualController>().GetSurvivalTime();

            // Ocena na podstawie czasu prze�ycia
            individual.GetComponent<IndividualController>().SetFitness(survivalTime);
        }
    }

    List<GameObject> Selection()
    {
        // Wybierz najlepsze osobniki na podstawie oceny (rankingowa selekcja)
        population.Sort((x, y) => y.GetComponent<IndividualController>().GetFitness().CompareTo(x.GetComponent<IndividualController>().GetFitness()));

        // Wybierz 50% najlepszych osobnik�w jako rodzic�w
        int selectionSize = Mathf.RoundToInt(populationSize * 0.5f);
        List<GameObject> selectedParents = population.GetRange(0, selectionSize);

        return selectedParents;
    }

    List<GameObject> Crossover(List<GameObject> parents)
    {
        List<GameObject> offspring = new List<GameObject>();

        while (offspring.Count < populationSize)
        {
            // Losowe wybieranie dw�ch rodzic�w
            int parentIndex1 = Random.Range(0, parents.Count);
            int parentIndex2 = Random.Range(0, parents.Count);

            GameObject parent1 = parents[parentIndex1];
            GameObject parent2 = parents[parentIndex2];

            // Tworzenie potomstwa poprzez krzy�owanie strategii rodzic�w
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
        // Usuni�cie poprzedniej populacji
        foreach (GameObject individual in population)
        {
            Destroy(individual);
        }
        population.Clear();

        // Dodanie nowej populacji
        population.AddRange(offspring);
    }
}
