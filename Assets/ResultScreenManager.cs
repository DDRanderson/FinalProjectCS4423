using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultScreenManager : MonoBehaviour
{

    [SerializeField] TMP_Text resultsText;

    void Start(){

        if (FinalResultsValues.finalMoneyScore >= 0)
            resultsText.text = "You Win!\nFinal Score: $" + FinalResultsValues.finalMoneyScore;
        else   
            resultsText.text = "You Lose\nFinal Score: $" + FinalResultsValues.finalMoneyScore;
    }

    public void PlayAgain(){
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame(){
        Application.Quit();
    }

}
