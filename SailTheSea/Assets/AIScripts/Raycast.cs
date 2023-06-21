using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Raycast : MonoBehaviour
{
    public float raycastDistance = 10f;
    public LayerMask layerMask;
    public Color rayColor = Color.red;

    private PossibleMoves possibleMoves;

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
            int playerCurrentIndex = possibleMoves.spawnIndex;
            Debug.Log(playerCurrentIndex);
            SavePlayerCurrentIndex(playerCurrentIndex);
        }

        Vector2 raycastDirectionLeft = -transform.right;
        RaycastHit2D hitLeft = Physics2D.Raycast(raycastOrigin, raycastDirectionLeft, raycastDistance, layerMask);
        if (hitLeft.collider != null && hitLeft.collider.CompareTag("Player"))
        {
            int playerCurrentIndex = possibleMoves.spawnIndex;
            Debug.Log(playerCurrentIndex);
            SavePlayerCurrentIndex(playerCurrentIndex);
        }

        Debug.DrawLine(raycastOrigin, raycastOrigin + raycastDirectionRight * raycastDistance, rayColor);
        Debug.DrawLine(raycastOrigin, raycastOrigin + raycastDirectionLeft * raycastDistance, rayColor);
    }

    private void SavePlayerCurrentIndex(int index)
    {
        string filePath = "PlayerCurrentIndex.txt";

        
        StreamWriter writer = new StreamWriter(filePath, false);

       
        writer.WriteLine(index);

       
        writer.Close();

        Debug.Log("PlayerCurrentIndex saved to file.");
    }

}
