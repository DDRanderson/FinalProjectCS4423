using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ResolutionSettings : MonoBehaviour
{

    [SerializeField] TMP_Dropdown resolutionDrowndown;
    Resolution[] resolutions;

    void Start(){
        resolutions = Screen.resolutions;
        Resolution currentResolution = Screen.currentResolution;
        int currentResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", resolutions.Length - 1);
        for(int i = 0; i<resolutions.Length; i++){
            string resolutionString = resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString();
            resolutionDrowndown.options.Add(new TMP_Dropdown.OptionData(resolutionString));
            if(currentResolution.Equals(resolutions[i])){
                resolutionDrowndown.value = i;
            }
        }
        currentResolutionIndex = Math.Min(currentResolutionIndex, resolutions.Length-1);
        resolutionDrowndown.value = currentResolutionIndex;
        SetResolution();
    }

    public void SetResolution(){
        int rezIndex = resolutionDrowndown.value;
        Screen.SetResolution(resolutions[rezIndex].width, resolutions[rezIndex].height, true);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionDrowndown.value);
    }

}
