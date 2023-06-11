using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanScene : MonoBehaviour
{
    [SerializeField] PlayerHealth HealthCheck;
    public GameObject ScoreCanvas;

    void Update()
    {
        if(HealthCheck.health <= 0)
        {
            Destroy(ScoreCanvas);
        }
    }
}
