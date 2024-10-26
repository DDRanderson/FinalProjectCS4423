using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MoneyManager : MonoBehaviour
{
    [Header("Money Values")]
    public int currentMoney = 300;
    public int dailyExpenses = 100;

    [SerializeField] TMP_Text moneyText;


    void Start(){
        moneyText.text = "$" + currentMoney;

        //subscribe to oneSecondTrigger event
        FindObjectOfType<TimeManager>().endOfDayEvent += EndOfDay;
    }

    void EndOfDay(){
        currentMoney -= dailyExpenses;
        moneyText.text = "$" + currentMoney;
    }

}
