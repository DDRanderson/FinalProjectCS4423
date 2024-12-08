using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioClip[] trashAudioClipArray;
    public AudioClip cashRegisterAudioClip;
    public AudioClip powerUpClip;
    public AudioClip powerDownClip;
    public AudioClip recycleTrashClip;
    public AudioSource effectSource;
    private int trashClipIndex;


    
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Player>().collectTrashEvent += PlayRandomTrashSound;
        FindObjectOfType<Player>().recycleTrashEvent += PlayRecycleTrashSound;
        FindObjectOfType<Player>().collectRentEvent += PlayCashRegisterSound;
        FindObjectOfType<Player>().drinkCoffeeEvent += PlayPowerUpSound;
        FindObjectOfType<Player>().coffeeEndEvent += PlayPowerDownSound;

        trashClipIndex = Random.Range(0,trashAudioClipArray.Length-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void PlayRandomTrashSound() {
        
        if (trashClipIndex < trashAudioClipArray.Length && trashClipIndex >= 0)
        {
            effectSource.PlayOneShot(trashAudioClipArray[trashClipIndex]);
            trashClipIndex = Random.Range(0,trashAudioClipArray.Length-1);
        }
    }

    void PlayCashRegisterSound(){
        effectSource.PlayOneShot(cashRegisterAudioClip);
    }

    void PlayPowerUpSound(){
        effectSource.PlayOneShot(powerUpClip);
    }

    void PlayPowerDownSound(){
        effectSource.PlayOneShot(powerDownClip);
    }

    void PlayRecycleTrashSound(){
        effectSource.PlayOneShot(recycleTrashClip);
    }
}
