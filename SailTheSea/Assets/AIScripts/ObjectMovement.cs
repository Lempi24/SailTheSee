using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Vector2 velocity;

    private void Update()
    {
        // Przesuwanie obiektu na podstawie pr�dko�ci
        transform.Translate(velocity * Time.deltaTime);
    }
}
