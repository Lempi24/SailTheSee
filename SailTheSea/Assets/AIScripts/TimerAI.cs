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
    public GeneticAlgorithm PlayerCheck;

    void Update()
    {
        
        //Jezeli jest obiekt o tagu player na scenie to liczy sie czas
        if (PlayerCheck.PlayerAI.scene.IsValid() == true)
        {
                if(PlayerCheck.PlayerAI.scene.IsValid() == false)
                {
                    
                }   
                timeSurvivedAI += Time.deltaTime;
                UpdateTimeTextAI();
        }
        else
        {
            timeSurvivedAI = 0f;
        }
        
    }
    //Funkcja wyswietlania czasu
    public void UpdateTimeTextAI()
    {
        minutesAI = Mathf.FloorToInt(timeSurvivedAI / 60f);
        secondsAI = Mathf.FloorToInt(timeSurvivedAI % 60f);

        TimerAIDisplay.text = "Time: " + minutesAI.ToString("00") + ":" + secondsAI.ToString("00");
    }
}
