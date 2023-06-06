using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            // Sprawd�, czy gracz ma odpalon� tarcz�
            bool hasShieldActive = collision.gameObject.GetComponent<BoatMovement>().isShieldActive;

            // Je�li gracz nie ma odpalonej tarczy, zadaj mu obra�enia
            if (!hasShieldActive)
            {
                playerHealth.TakeDamage(3);
            }
        }
    }
}