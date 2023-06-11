using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighestScore : MonoBehaviour
{
    public TextMeshProUGUI HighestScoreText;
    void Start()
    {
        HighestScoreText.text = "Highest Score: " + PlayerPrefs.GetFloat("HighScoreMinutes").ToString("00") + ":" + PlayerPrefs.GetFloat("HighScoreSeconds").ToString("00");  
    }
}