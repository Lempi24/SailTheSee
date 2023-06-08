using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualController : MonoBehaviour
{
    private Vector3 moveDirection;
    private float movementSpeed = 5f; 

    private float survivalTime; 
    private float fitness;

    void Start()
    {
        
        moveDirection = Vector3.zero;
        survivalTime = 0f;
        fitness = 0f;
    }

    void Update()
    {
        
        transform.Translate(moveDirection * movementSpeed * Time.deltaTime);

       
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
        

        IndividualController parent1Controller = parent1.GetComponent<IndividualController>();
        IndividualController parent2Controller = parent2.GetComponent<IndividualController>();

       
        moveDirection = (parent1Controller.moveDirection + parent2Controller.moveDirection) / 2f;
    }

    public void MutateStrategy()
    {
        
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        moveDirection = new Vector3(randomX, randomY, 0f).normalized;
    }
}
