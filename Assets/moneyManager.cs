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
    [SerializeField] TMP_Text moneyResultText;
    
    

    [Header("Money Values")]
    public int currentMoney = 300;
    public int dailyExpenses = 120;
    public int maxRentMoney = 20;
    public int moneyResult = 0;
    public int coffeeCost = 3;
    public int recyclePayment = 2;
    public Color moneyResultColor;
    public bool hasCollectedRent = false;
    [SerializeField] float fadeDuration = 2f;
    float fadeTimer = 0;

    public Trash[] trashList;


    void Start(){
        moneyResultColor = new Color(0,0,0,0);
        moneyResultText.color = moneyResultColor;
        //moneyResultText.text = "0";*/
        try{
            moneyText.text = "$" + currentMoney;
            
        }
        catch (NullReferenceException e){
            Debug.Log("MoneyManager Money Text: Null Ref Exc");
        }
        //subscribe to oneSecondTrigger event
        FindObjectOfType<TimeManager>().endOfDayEvent += EndOfDay;
        FindObjectOfType<Player>().collectRentEvent += CollectedRent;
        FindObjectOfType<Player>().drinkCoffeeEvent += PayForCoffee;
        FindObjectOfType<Player>().recycleTrashEvent += RecycleTrash;
    }

    //void Update(){
        //if (hasCollectedRent){PositiveMoneyResultVisualizer();}
    //}

    void EndOfDay(){
        moneyResultColor = new Color(1,0,0,1);
        moneyResultText.text = "-$" + dailyExpenses;
        moneyResultText.color = moneyResultColor;
        currentMoney -= dailyExpenses;
        try{
            moneyText.text = "$" + currentMoney;
        }
        catch (NullReferenceException e){
            Debug.Log("MoneyManager Money Text: Null Ref Exc");
        }
    }

    void CollectedRent(){
        // find how much trash exists on property
        trashList = FindObjectsByType<Trash>(FindObjectsSortMode.None);
        //Debug.Log("Trash Count:" + trashList.Length);

        // check to make sure you aren't paying money to tenant if there is too much trash 
        // -$2 per trash, 10 trash = $0 collected 
        if (maxRentMoney > (trashList.Length * 2)){
            moneyResult = maxRentMoney - (trashList.Length * 2);
            moneyResultColor = new Color(0,1,0,1);
            moneyResultText.text = "+$" + moneyResult;
            moneyResultText.color = moneyResultColor;
            //hasCollectedRent = true;
            currentMoney += moneyResult;
        } else {
            moneyResult = 0;
            moneyResultColor = new Color(1,1,1,1);
            moneyResultText.color = moneyResultColor;
            moneyResultText.text = "$" + moneyResult;
        }

        try{
            moneyText.text = "$" + currentMoney;
        }
        catch (NullReferenceException e){
            Debug.Log("MoneyManager Money Text: Null Ref Exc");
        }
    }

    void PositiveMoneyResultVisualizer(){
        fadeTimer += Time.deltaTime;
        
        float alpha = Mathf.Lerp(1f,0f, fadeTimer / fadeDuration);

        Color newColor = moneyResultColor;
        newColor.a = alpha;
        moneyResultText.color = newColor;

        if(fadeTimer >= fadeDuration){
            hasCollectedRent = false;
            moneyResultText.color = new Color(0,0,0,0);
        }
    }

    void PayForCoffee(){
        moneyResultColor = new Color(1,0,0,1);
        moneyResultText.text = "-$" + coffeeCost;
        moneyResultText.color = moneyResultColor;
        currentMoney -= coffeeCost;
        moneyText.text = "$" + currentMoney;
    }

    void RecycleTrash(){
        moneyResultColor = new Color(0,1,0,1);
        moneyResultText.text = "+$" + recyclePayment;
        moneyResultText.color = moneyResultColor;
        currentMoney += recyclePayment;
        moneyText.text = "$" + currentMoney;
    }

}
