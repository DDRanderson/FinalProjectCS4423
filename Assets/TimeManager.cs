using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeManager : MonoBehaviour
{

    public delegate void oneSecond();
    public event oneSecond oneSecondEvent; 

    [Header("Text Fields")]
    [SerializeField] TMP_Text clockText;
    [SerializeField] TMP_Text moneyText;

    [Header("Real Timer")]
    public int realTimer = 0;

    [Header("Clock Details")]
    public string clockStartShownTime = "9:00 AM";
    public int gameMinutes = 0;
    public int gameHours = 9;
    public string meridiem = "AM";

    [Header("Days of the Week")]
    static List<String> Days = new List<String>{"Mon","Tue","Wed","Thu","Fri"};
    public static int iDay = 0;
    string day = Days[iDay];

    [Header("Money Details")]
    public int currentMoney = 300;
    public int dailyExpenses = 100;


    void Start()
    {
        clockText.text = day + " - " + clockStartShownTime;
        moneyText.text = "$" + currentMoney;
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
            if (realTimer % 7 == 0){
                gameMinutes +=15;
                updateClockText(); 
            }
        }
    }

    void oneSecondTrigger(){
        if (oneSecondEvent != null){
            oneSecondEvent();
        }
    }

    public void updateClockText()
    {
        //60 minutes = 1 hour
        if(gameMinutes % 60 == 0){
            gameHours ++;
            gameMinutes = 0;
        }
        //switch from AM to PM
        if(gameHours % 13 == 0){
            gameHours = 1;
            meridiem = "PM";
        }
        //reset clock at end of the day, move to next Day of the Week, subtract daily expenses from Money
        if(realTimer % 252 == 0){
            realTimer = 0;
            gameMinutes = 0;
            gameHours = 9;
            meridiem = "AM";
            iDay++;
            if (iDay >= Days.Count){
                iDay = 0;
            }
            day = Days[iDay];

            updateMoneyText();

        }
        clockText.text = day + " - " + gameHours.ToString() + ":" + gameMinutes.ToString("00") + " " + meridiem;
    }

    public void updateMoneyText()
    {
        currentMoney -= dailyExpenses;
        moneyText.text = "$" + currentMoney;
    }
}
