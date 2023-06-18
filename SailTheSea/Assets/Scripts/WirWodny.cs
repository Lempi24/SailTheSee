using UnityEngine;

public class WirWodny : MonoBehaviour
{
    public float slowSpeed = 0.6f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Sprawdza, czy zderzenie dotyczy statku gracza (o tagu "Player").
        {
            BoatMovement boat = collision.GetComponent<BoatMovement>(); // Pobiera skrypt BoatMovement ze statku gracza.

            if (boat != null)
            {
                boat.moveSpeed = slowSpeed; // Ustawia prędkość statku gracza na wartość spowolnienia.
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Sprawdza, czy zderzenie dotyczy statku gracza (o tagu "Player").
        {
            BoatMovement boat = collision.GetComponent<BoatMovement>(); // Pobiera skrypt BoatMovement ze statku gracza.

            if (boat != null)
            {
                boat.moveSpeed = 2f; // Przywraca oryginalną prędkość statku gracza.
            }
        }
    }
}