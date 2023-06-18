using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class DamageOnCollision : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            BoatMovement boatMovement = collision.gameObject.GetComponent<BoatMovement>();
           
            bool hasShieldActive = boatMovement.isShieldActive;
            bool isShieldBlinking = boatMovement.isShieldBlinking;
            bool isShipBlinking = boatMovement.isShipBlinking;
            
            if (isShipBlinking) 
        {
            return;
        }
            
            if (!hasShieldActive)
            {
                playerHealth.TakeDamage(3);
                CameraShaker.Instance.ShakeOnce(4f, 2f, .1f, 1f);

            if (!boatMovement.isShipBlinking)
        {
            StartCoroutine(boatMovement.StartShipBlinkCoroutine());
            CameraShaker.Instance.ShakeOnce(4f, 2f, .1f, 1f);
        }
        
            }
            else if (hasShieldActive || isShieldBlinking)
            {               
                boatMovement.DisableShield();
            }
        }
    }
}