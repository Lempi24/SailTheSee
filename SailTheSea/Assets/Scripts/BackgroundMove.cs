using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float speed = 4f, time = 0f;
    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        time += Time.deltaTime;
        if (transform.position.y < -6.70512f)
        {
            StartPosition.y = 6.95f;
            transform.position = StartPosition;
        }
        if (time > 30f)
        {
            speed += 0.1f;
            time = 0f;
        }
    }
}
