using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class YourScore : MonoBehaviour
{
    public TextMeshProUGUI YourTimeIs;
    public ScoreManager TimeCheck;

    void Start()
    {
        YourTimeIs.text = "YOUR SCORE: " + TimeCheck.minutes.ToString("00") + ":" + TimeCheck.seconds.ToString("00");
    }
}