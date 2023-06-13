using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerAI : MonoBehaviour
{
    public int minutesAI = 0;
    public int secondsAI = 0;
    private float timeSurvivedAI = 0f;
    public TextMeshProUGUI TimerAIDisplay;
    public GameObject PlayerAI;

    void Update()
    {
        PlayerAI = GameObject.FindGameObjectWithTag("Player");
        if (PlayerAI.scene.IsValid() == true) //Wstaw tu pozniej co generacje
        {
                timeSurvivedAI += Time.deltaTime;
                UpdateTimeTextAI();
        }
        else
        {
            timeSurvivedAI = 0f;
        }
        
    }
    public void UpdateTimeTextAI()
    {
        minutesAI = Mathf.FloorToInt(timeSurvivedAI / 60f);
        secondsAI = Mathf.FloorToInt(timeSurvivedAI % 60f);

        TimerAIDisplay.text = "Time: " + minutesAI.ToString("00") + ":" + secondsAI.ToString("00");
    }
}
