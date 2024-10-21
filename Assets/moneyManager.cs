using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class moneyManager : MonoBehaviour
{
    public TMP_Text moneyText;

    [SerializeField] dayTimer dayTimer;
    public int startingMoney = 300;
    bool isMoneyUpdated = false;

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "$" + startingMoney;
    }

    void FixedUpdate(){
        if(dayTimer.getRealTimer() % 252 == 0 && dayTimer.getRealTimer() > 0){
            if(!isMoneyUpdated){
            startingMoney -= 100;
            updateMoneyText();
            isMoneyUpdated = true;
            }
        }
        else{
            isMoneyUpdated = false;
        }
    }

    void updateMoneyText(){
        moneyText.text = "$" + startingMoney;
    }


}
