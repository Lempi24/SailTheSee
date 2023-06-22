using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI Score;
    private float TimeAI =0f;
    public ObstacleSpawnerAI ResetCheck;
    private void Start()
    {
        TimeAI = 0f;
    }
    void Update()
    {
        TimeAI += Time.deltaTime;

        if (ResetCheck.SpawnReset > 0)
        {
            TimeAI = 0f;
        }

        Score.text = "Time: " + TimeAI.ToString("00");
    }
}
