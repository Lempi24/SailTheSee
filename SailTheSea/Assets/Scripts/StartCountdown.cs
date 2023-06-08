using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class StartCountdown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 5f;

    public TextMeshProUGUI CountdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        UpdateCountdownText();
    }

    void UpdateCountdownText()
    {
        if (currentTime <= 3.5f)
        {
            CountdownText.color = Color.red;
        }
        if (currentTime > 1f)
        {
            CountdownText.text = currentTime.ToString("0");
        }
        if (currentTime < 1f)
        {
            CountdownText.text = "Start!";
        }
        if (currentTime < 0f)
        {
            CountdownText.text = "";
        }
    }
}
