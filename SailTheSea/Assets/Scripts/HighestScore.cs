using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighestScore : MonoBehaviour
{
    public TextMeshProUGUI HighestScoreText;
    void Start()
    {
        HighestScoreText.text = "Best Time: " + PlayerPrefs.GetFloat("HighScoreMinutes").ToString("00") + ":" + PlayerPrefs.GetFloat("HighScoreSeconds").ToString("00");  
    }
}