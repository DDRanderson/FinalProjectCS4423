using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class dayTimer : MonoBehaviour
{

    public TMP_Text clockText;

    public string clockStartShownTime = "9:00 AM";
    public int realTimer = 0;
    public int gameMinutes = 0;
    public int gameHours = 9;
    public string meridiem = "AM";

    static List<String> Days = new List<String>{"Mon","Tue","Wed","Thu","Fri"};
    int iDay = 0;
    string day = Days[0];
    
    
 
    void Start()
    {
        //clockText.text = DateTime.Now.ToString();
        clockText.text = day + " - " + clockStartShownTime;
        StartCoroutine(TimerCouroutine());
    }

    IEnumerator TimerCouroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            realTimer++;
            //each 7 real seconds = 15 game minutes
            //each day is 252 seconds (9am to 6pm)
            if (realTimer % 7 == 0){
                gameMinutes +=15;
                updateClockText();
            }
        }

    }

    public void updateClockText()
    {
        if(gameMinutes % 60 == 0){
            gameHours ++;
            gameMinutes = 0;
        }
        if(gameHours % 13 == 0){
            gameHours = 1;
            meridiem = "PM";
        }
        if(realTimer % 252 == 0){
            gameMinutes = 0;
            gameHours = 9;
            meridiem = "AM";
            realTimer = 0;
            /*
            for(int i = 0; i < Days.Count; i++){
                string temp = Days[i];
                if(temp == day){
                    day = Days[i++];
                }
            }
            */
            iDay++;
            if (iDay >= Days.Count){
                iDay = 0;
            }
            day = Days[iDay];
        }
        clockText.text = day + " - " + gameHours.ToString() + ":" + gameMinutes.ToString("00") + " " + meridiem;
    }

    public int getRealTimer(){
        return realTimer;
    }

}
