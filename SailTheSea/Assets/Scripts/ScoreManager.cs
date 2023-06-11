using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private bool startTimer = false;
    private float timeSurvived = 0f;
    public static float HighScoreMinutes = 0f;
    public static float HighScoreSeconds = 0f;
    private float PreviousScore = 0f;
    public UIManager uimanager;


    void Start()
    {
        StartCoroutine(StartTimerAfterDelay(5f));
        PreviousScore = PlayerPrefs.GetFloat("HighScore");
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
