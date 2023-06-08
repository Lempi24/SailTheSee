using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthAI : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public float health, maxHealth;
    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {

    }

    public void TakeDamage(float amount)
    {

        health -= amount;
        OnPlayerDamaged?.Invoke();
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
            OnPlayerDeath?.Invoke();
        }
    }
}
