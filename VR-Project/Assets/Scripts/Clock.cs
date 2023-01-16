using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    private float clock = 0.0f;
    private string time;
    public TMP_Text timeSurvivedText;
    public TMP_Text timeText;
    private GameObject Player;
    private playerLife playerLife;
    private bool timeDisplayed = false;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        playerLife = Player.GetComponent<playerLife>();
        clock = 0.0f;

    }
    void Update()
    {
        if (!playerLife.isDead)
        {
            clock += Time.deltaTime;
            CalculateTime();
            timeText.text = time;
        }
        else
        {
            if (!timeDisplayed)
            {
                DisplayTime();
            }
        }
    }

    void CalculateTime()
    {
        int minutes = Mathf.FloorToInt(clock / 60.0f);
        int seconds = Mathf.FloorToInt(clock - minutes * 60);
        time = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void DisplayTime()
    {
        timeSurvivedText.text = "Time survived:  " + time;
        timeDisplayed = true;
    }
}
