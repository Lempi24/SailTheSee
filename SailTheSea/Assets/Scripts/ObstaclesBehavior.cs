using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBehavior : MonoBehaviour
{

    private Camera mainCamera;
    public float speed = 5f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < mainCamera.transform.position.y - mainCamera.orthographicSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision, true);
        }
    }

}
