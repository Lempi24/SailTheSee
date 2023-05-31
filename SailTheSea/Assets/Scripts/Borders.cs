using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    private float minX, maxX, minY, maxY;

    private void Start()
    {
        
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        minX = -screenBounds.x + 0.3f;
        maxX = screenBounds.x - 0.3f;
        minY = -screenBounds.y + 0.3f;
        maxY = screenBounds.y - 0.3f;
    }

    private void LateUpdate()
    {
        
        Vector3 currentPosition = transform.position;

       
        float clampedX = Mathf.Clamp(currentPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(currentPosition.y, minY, maxY);

        
        transform.position = new Vector3(clampedX, clampedY, currentPosition.z);
    }
}
