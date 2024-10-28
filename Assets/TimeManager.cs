using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

    public delegate void timeEvents();
    public event timeEvents oneSecondEvent;
    public event timeEvents endOfDayEvent; 
    public event timeEvents endOfWeekEvent;

    [Header("Text Fields")]
    [SerializeField] TMP_Text clockText;


    [Header("Real Timer")]
    public int realTimer = 0;

    [Header("Clock Details")]
    public string clockStartShownTime = "9:00 AM";
    public int gameMinutes = 0;
    public int gameHours = 9;
    public string meridiem = "AM";

    [Header("Days of the Week")]
    static List<string> Days = new List<string>{"Mon","Tue","Wed","Thu","Fri"};
    public static int iDay = 0;
    string day = Days[iDay];



    void Start()
    {
        clockText.text = day + " - " + clockStartShownTime;
        StartCoroutine(TimerCouroutine());
    }

    IEnumerator TimerCouroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            realTimer++;
            oneSecondTrigger();
            //each 7 real seconds = 15 game minutes
            //each day is 252 seconds (9am to 6pm)
            //can change the modulo number to increase/decrease how often 15 game minutes pass
            //for testing basic gameplay loop, reduced to 2 seconds per 15 game minutes
            if (realTimer % 2 == 0){
                gameMinutes +=15;
                updateClockText(); 
            }
        }
    }

    /****************/
    /*EVENT TRIGGERS*/
    /****************/
    void oneSecondTrigger(){
        if (oneSecondEvent != null){
            oneSecondEvent();
        }
    }

    void endOfDayTrigger(){
        if (endOfDayEvent != null){
            endOfDayEvent();
        }
    }

    void endOfWeekTrigger(){
        endOfWeekEvent?.Invoke();
    }



    public void updateClockText()
    {
        //60 minutes = 1 hour
        if(gameMinutes % 60 == 0){
            gameHours ++;
            gameMinutes = 0;
        }
        //switch from AM to PM
        if(gameHours % 12 == 0){
            meridiem = "PM";
        }
        //switch from military time to 12-hr time
        if(gameHours % 13 == 0){
            gameHours = 1;
        }
        //END OF DAY
        //reset clock, move to next Day of the Week, call endOfDay event trigger
        if(gameHours == 6 && gameMinutes == 0){
            realTimer = 0;
            gameMinutes = 0;
            gameHours = 9;
            meridiem = "AM";
            iDay++;
            if (iDay >= Days.Count){
                iDay = 0;
                endOfDayTrigger();
                endOfWeekTrigger();
                SceneManager.LoadScene("ResultsScreen");
                return;
            }
            day = Days[iDay];
            endOfDayTrigger();

        }
        clockText.text = day + " - " + gameHours.ToString() + ":" + gameMinutes.ToString("00") + " " + meridiem;
    }

}
