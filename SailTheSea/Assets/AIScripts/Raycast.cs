using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float raycastDistance = 10f;
    public LayerMask layerMask;
    public Color rayColor = Color.red;

    private void Update()
    {
        Vector2 raycastOrigin = transform.position;

        // Wykonywanie raycasta w prawo
        Vector2 raycastDirectionRight = transform.right;
        RaycastHit2D hitRight = Physics2D.Raycast(raycastOrigin, raycastDirectionRight, raycastDistance, layerMask);
        if (hitRight.collider != null && hitRight.collider.CompareTag("Player"))
        {
            Debug.Log("Gracz zosta³ dotkniêty!");
        }

        // Wykonywanie raycasta w lewo
        Vector2 raycastDirectionLeft = -transform.right;
        RaycastHit2D hitLeft = Physics2D.Raycast(raycastOrigin, raycastDirectionLeft, raycastDistance, layerMask);
        if (hitLeft.collider != null && hitLeft.collider.CompareTag("Player"))
        {
            Debug.Log("Gracz zosta³ dotkniêty!");
        }

        // Rysowanie linii raycastów
        Debug.DrawLine(raycastOrigin, raycastOrigin + raycastDirectionRight * raycastDistance, rayColor);
        Debug.DrawLine(raycastOrigin, raycastOrigin + raycastDirectionLeft * raycastDistance, rayColor);
    }


}
