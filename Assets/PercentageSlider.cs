using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PercentageSlider : MonoBehaviour
{

    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI percentageText;


    public void SetPercentage(){
        percentageText.text = (slider.value * 100).ToString("F0") + "%";
    }


}
