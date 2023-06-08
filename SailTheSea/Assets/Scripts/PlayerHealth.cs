using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public float health, maxHealth;
    public float DamageCooldown = 2f;
    void Start()
    {
        health = maxHealth;    
    }

    private void Update()
    {
        DamageCooldown -= Time.deltaTime;
    }

    public void TakeDamage(float amount)
    {
        if (DamageCooldown <= 0f)
        {
            health -= amount;
            OnPlayerDamaged?.Invoke();
            DamageCooldown = 2f;
        }
        
        if(health <=0)
        {
            health = 0;
            Destroy(gameObject);
            OnPlayerDeath?.Invoke();
        }
    }
}
