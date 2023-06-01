using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleControler : MonoBehaviour
{
    public Transform player;
    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void LateUpdate()
    {
        // Oblicz kierunek przeciwny do ruchu gracza
        Vector2 direction = transform.position - player.position;
        direction.Normalize();

        // Oblicz k�t obrotu w stopniach
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Obr�� Particle System
        var mainModule = particleSystem.main;
        mainModule.startRotation = angle;
    }
}
