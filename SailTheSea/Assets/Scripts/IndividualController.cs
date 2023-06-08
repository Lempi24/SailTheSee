using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualController : MonoBehaviour
{
    private Vector3 moveDirection; // Kierunek ruchu
    private float movementSpeed = 5f; // Pr�dko�� poruszania si�

    private float survivalTime; // Czas prze�ycia
    private float fitness; // Ocena (czas prze�ycia)

    void Start()
    {
        // Inicjalizacja startowych warto�ci
        moveDirection = Vector3.zero;
        survivalTime = 0f;
        fitness = 0f;
    }

    void Update()
    {
        // Poruszanie si� zgodnie z kierunkiem ruchu
        transform.Translate(moveDirection * movementSpeed * Time.deltaTime);

        // Zwi�kszanie czasu prze�ycia
        survivalTime += Time.deltaTime;
    }

    public float GetSurvivalTime()
    {
        return survivalTime;
    }

    public void SetFitness(float value)
    {
        fitness = value;
    }

    public float GetFitness()
    {
        return fitness;
    }

    public void CombineStrategies(GameObject parent1, GameObject parent2)
    {
        // Implementacja krzy�owania strategii rodzic�w
        // Mo�esz dostosowa� ten fragment kodu w zale�no�ci od konkretnej strategii poruszania si�

        IndividualController parent1Controller = parent1.GetComponent<IndividualController>();
        IndividualController parent2Controller = parent2.GetComponent<IndividualController>();

        // Przyk�adowe krzy�owanie: �rednia warto�ci ruchu z obu rodzic�w
        moveDirection = (parent1Controller.moveDirection + parent2Controller.moveDirection) / 2f;
    }

    public void MutateStrategy()
    {
        // Implementacja mutacji strategii
        // Mo�esz dostosowa� ten fragment kodu w zale�no�ci od konkretnej strategii poruszania si�

        // Przyk�adowa mutacja: losowe zmiany w kierunku ruchu
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        moveDirection = new Vector3(randomX, randomY, 0f).normalized;
    }
}
