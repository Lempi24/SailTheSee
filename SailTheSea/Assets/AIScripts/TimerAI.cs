using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerAI : MonoBehaviour
{
    public int minutesAI = 0;
    public int secondsAI = 0;
    public PlayerHealthAI PlayerHealthAICheck;
    private float timeSurvivedAI = 0f;
    public TextMeshProUGUI TimerAIDisplay;

    void Update()
    {
        if (PlayerHealthAICheck.health > 0) //Wstaw tu pozniej co generacje
        {
                timeSurvivedAI += Time.deltaTime;
                UpdateTimeTextAI();
        }
        
    }
    public void UpdateTimeTextAI()
    {
        minutesAI = Mathf.FloorToInt(timeSurvivedAI / 60f);
        secondsAI = Mathf.FloorToInt(timeSurvivedAI % 60f);

        TimerAIDisplay.text = "Time: " + minutesAI.ToString("00") + ":" + secondsAI.ToString("00");
    }
}
