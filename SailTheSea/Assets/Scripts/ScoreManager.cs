using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private bool startTimer = false;
    private float timeSurvived = 0f;

    void Start()
    {
        StartCoroutine(StartTimerAfterDelay(5f));
    }
    
    void Update()
    {
        if (startTimer)        
    {
        timeSurvived += Time.deltaTime;
        UpdateTimeText();
    }
    }

    void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(timeSurvived / 60f);
        int seconds = Mathf.FloorToInt(timeSurvived % 60f);

        timeText.text = "Czas: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    private IEnumerator StartTimerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        startTimer = true;
    }
}
