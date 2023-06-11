using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighestScore : MonoBehaviour
{
    public TextMeshProUGUI HighestScoreText;
    void Start()
    {
        HighestScoreText.text = "Highest Score: " + ScoreManager.HighScoreMinutes.ToString("00") + ":" + ScoreManager.HighScoreSeconds.ToString("00");  
    }
}