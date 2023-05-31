using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    private float minX, maxX, minY, maxY;

    private void Start()
    {
        // Obliczanie granic ekranu gry w jednostkach jednostki widoku
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        minX = -screenBounds.x + 0.3f;
        maxX = screenBounds.x - 0.3f;
        minY = -screenBounds.y + 0.3f;
        maxY = screenBounds.y - 0.3f;
    }

    private void LateUpdate()
    {
        // Pobieranie aktualnej pozycji gracza
        Vector3 currentPosition = transform.position;

        // Sprawdzanie, czy pozycja gracza przekracza granice ekranu gry
        float clampedX = Mathf.Clamp(currentPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(currentPosition.y, minY, maxY);

        // Aktualizowanie pozycji gracza z uwzglêdnieniem granic
        transform.position = new Vector3(clampedX, clampedY, currentPosition.z);
    }
}
