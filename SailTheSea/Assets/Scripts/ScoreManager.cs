using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public PlayerHealth HealthCheck2;
    private bool startTimer = false;
    private float timeSurvived = 0f;
    public static float HighScoreMinutes = 0f;
    public static float HighScoreSeconds = 0f;
    private float PreviousScore = 0f;
    public int minutes = 0;
    public int seconds = 0;


    void Start()
    {
        StartCoroutine(StartTimerAfterDelay(5f));
        PreviousScore = PlayerPrefs.GetFloat("HighScore");
    }
    
    void Update()
    {
        if (startTimer)
        {
            if (HealthCheck2.health > 0)
            {
                timeSurvived += Time.deltaTime;
                UpdateTimeText();
            }
        }
    }

    void UpdateTimeText()
    {
        minutes = Mathf.FloorToInt(timeSurvived / 60f); 
        seconds = Mathf.FloorToInt(timeSurvived % 60f);

        timeText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");

        if (timeSurvived >= PreviousScore)
        {
            HighScoreMinutes = minutes;
            HighScoreSeconds = seconds;
            PlayerPrefs.SetFloat("HighScore", timeSurvived);
            PlayerPrefs.SetFloat("HighScoreMinutes", HighScoreMinutes);
            PlayerPrefs.SetFloat("HighScoreSeconds", HighScoreSeconds);
        } 
    }
    private IEnumerator StartTimerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        startTimer = true;
    }
}
