using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;
    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float bubbleFormationPeriod;

    [SerializeField] Rigidbody2D rb;

    float counter;

    private void Update()
    {
        counter += Time.deltaTime;
    }
}
