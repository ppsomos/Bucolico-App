using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountDown : MonoBehaviour
{
    public  float timeRemaining;
    public  bool timerIsRunning = false;
    public TMP_Text timeText;

    public GameObject tryagain_panal;
    public RoomCompleteHandler RCH;
    
    
    private void Start()
    {
        timeRemaining = 300f;
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                if (GameManager.Instance.isMultiplayer)
                {
                    RCH.OnPlayerEnter();
                }
                else
                {
                    tryagain_panal.SetActive(true);
                }
            }
        }
    }

   


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}