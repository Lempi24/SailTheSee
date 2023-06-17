using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float speed = 1f, time = 0f;
    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        time += Time.deltaTime;
        if (transform.position.y < -6.70512f)
        {
            StartPosition.y = 13.91f;
            transform.position = StartPosition;
        }
        if (time > 30f && speed < 12f)
        {
            speed += 0.1f;
            time = 0f;
        }
    }
}
