using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Analytics;
using System.Linq;

public class MoneyManager : MonoBehaviour
{

    [SerializeField] TMP_Text moneyText;
    


    [Header("Money Values")]
    public int currentMoney = 300;
    public int dailyExpenses = 120;
    public int maxRentMoney = 20;

    public Trash[] trashList;


    void Start(){
        try{
            moneyText.text = "$" + currentMoney;
        }
        catch (NullReferenceException e){
            Debug.Log("MoneyManager Money Text: Null Ref Exc");
        }
        //subscribe to oneSecondTrigger event
        FindObjectOfType<TimeManager>().endOfDayEvent += EndOfDay;
        FindObjectOfType<Player>().collectRentEvent += CollectedRent;
    }

    void EndOfDay(){
        currentMoney -= dailyExpenses;
        try{
            moneyText.text = "$" + currentMoney;
        }
        catch (NullReferenceException e){
            Debug.Log("MoneyManager Money Text: Null Ref Exc");
        }
    }

    void CollectedRent(){
        //find how much trash exists on property
        trashList = FindObjectsByType<Trash>(FindObjectsSortMode.None);
        //Debug.Log("Trash Count:" + trashList.Length);

        //check to make sure you aren't paying money to tenant if there is too much trash 
        if (maxRentMoney > (trashList.Length * 2)){
            currentMoney += maxRentMoney - (trashList.Length * 2);
        }

        try{
            moneyText.text = "$" + currentMoney;
        }
        catch (NullReferenceException e){
            Debug.Log("MoneyManager Money Text: Null Ref Exc");
        }
    }

}
