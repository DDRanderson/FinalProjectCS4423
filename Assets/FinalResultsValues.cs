using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalResultsValues : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;
    [SerializeField] MoneyManager moneyManager;
    public static int finalMoneyScore;

    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start(){
        timeManager.endOfWeekEvent += SetMoneyScore;
    }

    void SetMoneyScore(){
        finalMoneyScore = moneyManager.currentMoney;
    }

}
