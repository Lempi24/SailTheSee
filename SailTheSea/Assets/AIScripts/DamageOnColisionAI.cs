using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnColisionAI : MonoBehaviour
{
    public PlayerHealthAI PlayerHealthAI;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            var PlayerHealthAI = collision.gameObject.GetComponent<PlayerHealthAI>();
            PlayerHealthAI.TakeDamage(3);
        }
    }
}
