using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class Raycast : MonoBehaviour
{
    public float raycastDistance = 10f;
    public LayerMask layerMask;
    public Color rayColor = Color.red;
    public float saveDelay = 1f;

    private IndividualController controller;
    private bool hasSavedIndex = false;

    private void Start()
    {
        controller = FindObjectOfType<IndividualController>();
    }

    private void Update()
    {
        Vector2 raycastOrigin = transform.position;
        //Raycast w prawo
        Vector2 raycastDirectionRight = transform.right;
        RaycastHit2D hitRight = Physics2D.Raycast(raycastOrigin, raycastDirectionRight, raycastDistance, layerMask);
        if (hitRight.collider != null && hitRight.collider.CompareTag("Player"))
        {
            //Jesli raycast obiektu trafi w Playera i dany index nie zosta� ju� wcze�niej zapisany to zapisuje si� index do pliku
            if (!hasSavedIndex)
            {
                int playerCurrentIndex = controller.spawnIndex;
                Debug.Log(playerCurrentIndex);
                controller.selectedIndexRay++;
                SavePlayerCurrentIndex(playerCurrentIndex);
                hasSavedIndex = true;
                Invoke("ResetSaveFlag", saveDelay);
                controller.Invoke("UpdateMove", 1);
            }
        }
        //Raycast w lewo
        Vector2 raycastDirectionLeft = -transform.right;
        RaycastHit2D hitLeft = Physics2D.Raycast(raycastOrigin, raycastDirectionLeft, raycastDistance, layerMask);
        if (hitLeft.collider != null && hitLeft.collider.CompareTag("Player"))
        {
            if (!hasSavedIndex)
            {
                int playerCurrentIndex = controller.spawnIndex;
                Debug.Log(playerCurrentIndex);
                controller.selectedIndexRay++;
                SavePlayerCurrentIndex(playerCurrentIndex);
                hasSavedIndex = true;
                Invoke("ResetSaveFlag", saveDelay);
                controller.Invoke("UpdateMove", 1);
            }
        }
        
        Debug.DrawLine(raycastOrigin, raycastOrigin + raycastDirectionRight * raycastDistance, rayColor);
        Debug.DrawLine(raycastOrigin, raycastOrigin + raycastDirectionLeft * raycastDistance, rayColor);
    }

    private void SavePlayerCurrentIndex(int index)
    {
        string fileName = "PlayerCurrentIndex.txt";
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        //Zapisywanie do pliku je�li zabraknie mu danych o danej fali
        if (controller.allValues.Count < controller.selectedIndexRay)
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, index.ToString());
            }
            else
            {
                File.AppendAllText(filePath, index.ToString() + ",");
            }
        }
    }

    private void ResetSaveFlag()
    {
        hasSavedIndex = false;
    }
}
