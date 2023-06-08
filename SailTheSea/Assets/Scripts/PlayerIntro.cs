using System.Collections;
using UnityEngine;

public class PlayerIntro : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject Position1;
    int i = 0;

    void Update()
    {
        if (i < 1)
        {
            if (Player.transform.position.y != Position1.transform.position.y)
            {
                transform.position = Vector2.MoveTowards(transform.position, Position1.transform.position, speed * Time.deltaTime);
            }
            if (Player.transform.position.y == Position1.transform.position.y)
            {
                i++;
            }
        }
    }
}
