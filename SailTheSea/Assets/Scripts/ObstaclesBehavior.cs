using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBehavior : MonoBehaviour
{

    private Camera mainCamera;
    public float speed = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        mainCamera = Camera.main;
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (0, -speed);
    }

    private void Update()
    {
        
        if (transform.position.y < mainCamera.transform.position.y - mainCamera.orthographicSize)
        {
            
            Destroy(gameObject);
        }
    }
}
