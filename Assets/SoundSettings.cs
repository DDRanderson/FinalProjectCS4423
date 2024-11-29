using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;

    string masterVolume = "MasterVolume";
    string musicVolume = "MusicVolume";
    string sfxVolume = "SFXVolume";

    void Start(){
        masterVolumeSlider.value = PlayerPrefs.GetFloat(masterVolume,0.5f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat(musicVolume,0.5f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat(sfxVolume,0.5f);
        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }

    public void SetMasterVolume(){
        //audioMixer.SetFloat("MasterVolume", masterVolumeSlider.value);
        SetVolume(masterVolume,masterVolumeSlider.value);
        PlayerPrefs.SetFloat(masterVolume, masterVolumeSlider.value);
    }

    public void SetMusicVolume(){
        
        SetVolume(musicVolume,musicVolumeSlider.value);
        PlayerPrefs.SetFloat(musicVolume, musicVolumeSlider.value);
    }

    public void SetSFXVolume(){
        
        SetVolume(sfxVolume,sfxVolumeSlider.value);
        PlayerPrefs.SetFloat(sfxVolume, sfxVolumeSlider.value);
    }

    void SetVolume(string groupName, float value){
        float adjustedVolume = Mathf.Log10(value) * 20;
        if (value == 0){
            adjustedVolume = -80;
        }
        audioMixer.SetFloat(groupName,adjustedVolume);
    }

}
