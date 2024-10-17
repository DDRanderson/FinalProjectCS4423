using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class dayTimer : MonoBehaviour
{

    public TMP_Text clockText;

    public string clockStartShownTime = "9:00";
    public int realTimer = 0;
    public int gameSeconds = 0;
    public int gameMinutes = 9;
    public string meridiem = "AM";
 
    void Start()
    {
        //clockText.text = DateTime.Now.ToString();
        clockText.text = clockStartShownTime;
        StartCoroutine(TimerCouroutine());
    }

    void Update()
    {

    }

    IEnumerator TimerCouroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            realTimer++;
            //each 7 real seconds = 15 game minutes
            //each day is 252 seconds (9am to 6pm)
            if (realTimer % 2 == 0){
                gameSeconds+=15;
                updateClockText();
            }
        }

    }

    public void updateClockText()
    {
        if(gameSeconds % 60 == 0){
            gameMinutes++;
            gameSeconds = 0;
        }
        if(gameMinutes % 13 == 0){
            gameMinutes = 1;
            meridiem = "PM";
        }
        clockText.text = gameMinutes.ToString() + ":" + gameSeconds.ToString("00") + " " + meridiem;
    }
}
