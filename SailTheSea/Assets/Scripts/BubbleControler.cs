using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleControler : MonoBehaviour
{
    public Transform player;
    private ParticleSystem particleSystem;
    private Transform particleTransform;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleTransform = transform;
    }

    private void LateUpdate()
    {
       
        Vector2 direction = player.position - particleTransform.position;
        direction.Normalize();

        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        
        particleTransform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
