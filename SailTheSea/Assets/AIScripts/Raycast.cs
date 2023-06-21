using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Raycast : MonoBehaviour
{
    public float raycastDistance = 10f;
    public LayerMask layerMask;
    public Color rayColor = Color.red;
    public float saveDelay = 1f; // OpóŸnienie (w sekundach) przed kolejnym zapisem

    private PossibleMoves possibleMoves;
    private bool hasSavedIndex = false;

    private void Start()
    {
        possibleMoves = FindObjectOfType<PossibleMoves>();
    }

    private void Update()
    {
        Vector2 raycastOrigin = transform.position;

        Vector2 raycastDirectionRight = transform.right;
        RaycastHit2D hitRight = Physics2D.Raycast(raycastOrigin, raycastDirectionRight, raycastDistance, layerMask);
        if (hitRight.collider != null && hitRight.collider.CompareTag("Player"))
        {
            if (!hasSavedIndex)
            {
                int playerCurrentIndex = possibleMoves.spawnIndex;
                Debug.Log(playerCurrentIndex);
                SavePlayerCurrentIndex(playerCurrentIndex);
                hasSavedIndex = true;

                Invoke("ResetSaveFlag", saveDelay); // Wywo³anie funkcji ResetSaveFlag() po okreœlonym opóŸnieniu
            }
        }

        Vector2 raycastDirectionLeft = -transform.right;
        RaycastHit2D hitLeft = Physics2D.Raycast(raycastOrigin, raycastDirectionLeft, raycastDistance, layerMask);
        if (hitLeft.collider != null && hitLeft.collider.CompareTag("Player"))
        {
            if (!hasSavedIndex)
            {
                int playerCurrentIndex = possibleMoves.spawnIndex;
                Debug.Log(playerCurrentIndex);
                SavePlayerCurrentIndex(playerCurrentIndex);
                hasSavedIndex = true;

                Invoke("ResetSaveFlag", saveDelay); // Wywo³anie funkcji ResetSaveFlag() po okreœlonym opóŸnieniu
            }
        }

        Debug.DrawLine(raycastOrigin, raycastOrigin + raycastDirectionRight * raycastDistance, rayColor);
        Debug.DrawLine(raycastOrigin, raycastOrigin + raycastDirectionLeft * raycastDistance, rayColor);
    }

    private void SavePlayerCurrentIndex(int index)
    {
        string filePath = "PlayerCurrentIndex.txt";

        // Sprawdzanie czy plik istnieje
        if (!File.Exists(filePath))
        {
            // Tworzenie pliku jeœli nie istnieje
            File.WriteAllText(filePath, index.ToString());
        }
        else
        {
            // Dopisywanie wartoœci do pliku
            File.AppendAllText(filePath, "\n" + index.ToString());
        }

        Debug.Log("PlayerCurrentIndex saved to file.");
    }

    private void ResetSaveFlag()
    {
        hasSavedIndex = false;
    }
}
