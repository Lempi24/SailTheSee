using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnColisionAI : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthAI playerHealth = collision.gameObject.GetComponent<PlayerHealthAI>();
            playerHealth.TakeDamage(3);

        }
    }
}
