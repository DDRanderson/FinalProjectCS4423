using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class dayTimer : MonoBehaviour
{

    public TMP_Text clockText;

    public int clockShownTime = 0;
 
    void Start()
    {
        //clockText.text = DateTime.Now.ToString();
        clockText.text = clockShownTime.ToString();
        StartCoroutine(TimerCouroutine());
    }

    void Update()
    {

    }

    IEnumerator TimerCouroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            updateClockText();
        }

    }

    public void updateClockText()
    {
        clockShownTime ++;
        clockText.text = clockShownTime.ToString();
    }
}
