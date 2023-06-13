using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthAI : MonoBehaviour
{
    public GeneticAlgorithm GenerationCountDecrease;
    public float health, maxHealth = 1;
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {

        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
            GenerationCountDecrease.GenerationCount 
        }
    }
}
