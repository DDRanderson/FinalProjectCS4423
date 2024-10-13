using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class dayTimer : MonoBehaviour
{

    public TMP_Text clockText;

    public int clockShownTime = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        //clockText.text = DateTime.Now.ToString();
        clockText.text = clockShownTime.ToString();
        StartCoroutine(TimerCouroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TimerCouroutine()
    {
        int x = 0;
        yield return new WaitForSeconds(2);
        updateClockText();
        Debug.Log("clockShownTime: " + clockShownTime);
        x++;
        Debug.Log("Coroutine timer: " + x);
    }

    public void updateClockText()
    {
        clockShownTime ++;
        clockText.text = clockShownTime.ToString();
    }
}
