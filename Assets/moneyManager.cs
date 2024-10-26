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
    public int dailyExpenses = 100;

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
        /*
        List<Trash> trashList = new List<Trash>();
        foreach (Trash go in Resources.FindObjectsOfTypeAll(typeof(Trash)) as Trash[]){
            trashList.Add(go);
        }
        */
        trashList = FindObjectsByType<Trash>(FindObjectsSortMode.None);
        
        Debug.Log("Trash Count:" + (trashList.Length - 1));

        currentMoney += 20;
        try{
            moneyText.text = "$" + currentMoney;
        }
        catch (NullReferenceException e){
            Debug.Log("MoneyManager Money Text: Null Ref Exc");
        }
    }

}
