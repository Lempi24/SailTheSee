using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            BoatMovement boatMovement = collision.gameObject.GetComponent<BoatMovement>();
            
            bool hasShieldActive = boatMovement.isShieldActive;
           
            if (!hasShieldActive)
            {
                playerHealth.TakeDamage(1);
            }
            else
            {               
                boatMovement.DisableShield();
            }
        }
    }
}