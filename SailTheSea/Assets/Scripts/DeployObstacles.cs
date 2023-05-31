using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployObstacles : MonoBehaviour
{
    public GameObject prefabToSpawn; // Prefab obiektu do tworzenia
    public float spawnRange = 10f; // Zakres losowej pozycji na osi X
    public float spawnInterval = 2f; // Interwa³ czasowy miêdzy tworzeniem obiektów

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

        // Wywo³aj funkcjê tworzenia obiektu w losowej pozycji na starcie gry
        SpawnRandomObject();

        // Wywo³aj funkcjê tworzenia obiektu co okreœlony czas
        InvokeRepeating("SpawnRandomObject", spawnInterval, spawnInterval);
    }

    private void SpawnRandomObject()
    {
        // Wylosuj losow¹ pozycjê na osi X w zakresie spawnRange
        float randomX = Random.Range(-spawnRange, spawnRange);

        // SprawdŸ granice widoku kamery
        float cameraLeftBound = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float cameraRightBound = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        // Skoryguj pozycjê X, aby obiekt nie wyszed³ poza widok kamery
        randomX = Mathf.Clamp(randomX, cameraLeftBound, cameraRightBound);

        // Twórz obiekt prefab w skorygowanej losowej pozycji na osi X
        Instantiate(prefabToSpawn, new Vector3(randomX, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
