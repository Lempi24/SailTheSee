using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealthAI : MonoBehaviour
{
    public float healthAI, maxHealth = 1;
    void Start()
    {
        healthAI = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        healthAI -= amount;
        if (healthAI <= 0)
        {
            healthAI = 0;
            Destroy(gameObject);
        }
    }
}
