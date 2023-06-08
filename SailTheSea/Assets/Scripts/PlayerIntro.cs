using System.Collections;
using UnityEngine;

public class PlayerIntro : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject Position1;
    int i = 0;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (i < 1)
        {
            rb.gravityScale = 0f;
            if (Player.transform.position.y != Position1.transform.position.y)
            {
                transform.position = Vector2.MoveTowards(transform.position, Position1.transform.position, speed * Time.deltaTime);
            }
            if (Player.transform.position.y == Position1.transform.position.y)
            {
                i++;
            }
        }
        if (i > 0)
        {
            rb.gravityScale = 2f;
        }
    }
}
