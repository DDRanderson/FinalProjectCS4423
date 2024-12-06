using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerGameplay : MonoBehaviour
{
    public AudioClip[] audioClipDays;
    public AudioSource audioSource;
    [SerializeField] TimeManager timeManager;
    // Start is called before the first frame update
    void Start()
    {
        PlayDayOfTheWeekSong();
        FindObjectOfType<TimeManager>().endOfDayEvent += EndOfDayEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayDayOfTheWeekSong(){
        switch (timeManager.getDayOfTheWeek()){
            case "Mon":
                audioSource.clip = audioClipDays[0];
                audioSource.Play();
                break;
            case "Tue":
                audioSource.clip = audioClipDays[1];
                audioSource.Play();
            break;
            case "Wed":
                audioSource.clip = audioClipDays[2];
                audioSource.Play();
            break;
            case "Thu":
                audioSource.clip = audioClipDays[3];
                audioSource.Play();
            break;
            case "Fri":
                audioSource.clip = audioClipDays[4];
                audioSource.Play();
            break;
            default:
                break;
        }
    }

    void EndOfDayEvent(){
        PlayDayOfTheWeekSong();
    }
}
