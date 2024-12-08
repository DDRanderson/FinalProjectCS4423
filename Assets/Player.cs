using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public delegate void PlayerEvents();
    public event PlayerEvents collectRentEvent;
    public event PlayerEvents collectTrashEvent;
    public event PlayerEvents recycleTrashEvent;
    public event PlayerEvents drinkCoffeeEvent;
    public event PlayerEvents coffeeEndEvent;
	
	public bool isBehindDesk = false;
    public bool isByCoffeeMachine = false;
    public bool hasDrinkenCoffee = false;
    public int coffeeTimer = 0;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip slurpClip;
    [SerializeField] GameObject particles;

    [Header("Movement")]
    [SerializeField] float speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindObjectOfType<TimeManager>().oneSecondEvent += OneSecondListenEvent;
        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Movement(Vector3 movement)
    {
        rb.velocity = movement * speed;
    }

    public void CollectRentTrigger(){
        if (collectRentEvent != null){
            collectRentEvent();
        }
    }

    public void CollectTrashTrigger(){
        collectTrashEvent?.Invoke();
    }

    public void RecycleTrashTrigger(){
        recycleTrashEvent?.Invoke();
    }

    public void DrinkCoffeeTrigger(){
        drinkCoffeeEvent?.Invoke();
    }

    public void CoffeeEndTrigger(){
        coffeeEndEvent?.Invoke();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("BehindDesk")){
			isBehindDesk = true;
        }

        if(collision.CompareTag("CoffeeMachine")){
            isByCoffeeMachine = true;
        }
    }
	
	void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("BehindDesk")){
			isBehindDesk = false;
        }

        if(collision.CompareTag("CoffeeMachine")){
            isByCoffeeMachine = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision){
        if(collision.CompareTag("Trash")){
            if(Input.GetKey(KeyCode.T)){
                //TrashDestroyedTrigger();
                Destroy(collision.gameObject);
                
                if (Random.Range(1,100) > 20){
                    CollectTrashTrigger();
                } else {
                    RecycleTrashTrigger();
                }
            }
        }
    }

    public void DrinkCoffee(){
        DrinkCoffeeTrigger();
        audioSource.PlayOneShot(slurpClip);
        hasDrinkenCoffee = true;
        speed = 5.8f;
        coffeeTimer = 20;
        particles.SetActive(true);
    }

    void OneSecondListenEvent(){
        if (coffeeTimer > 0){
            coffeeTimer--;
        }

        if(coffeeTimer <= 0){
            if (hasDrinkenCoffee){
                CoffeeEndTrigger();
            }
            hasDrinkenCoffee = false;
            coffeeTimer = 0;
            speed = 3.5f;
            particles.SetActive(false);
        }
    }
}
