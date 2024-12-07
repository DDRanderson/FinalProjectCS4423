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
    public event PlayerEvents drinkCoffeeEvent;
	
	public bool isBehindDesk = false;
    public bool isByCoffeeMachine = false;
    public bool hasDrinkenCoffee = false;
    public int coffeeTimer = 0;
    [SerializeField] AudioSource audioSource;

    [Header("Movement")]
    [SerializeField] float speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindObjectOfType<TimeManager>().oneSecondEvent += OneSecondListenEvent;
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

    public void DrinkCoffeeTrigger(){
        drinkCoffeeEvent?.Invoke();
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
                CollectTrashTrigger();
            }
        }

    }

    public void DrinkCoffee(){
        DrinkCoffeeTrigger();
        audioSource.Play();
        hasDrinkenCoffee = true;
        speed = 5f;
        coffeeTimer = 20;
    }

    void OneSecondListenEvent(){
        if (coffeeTimer > 0){
            coffeeTimer--;
        }

        if(coffeeTimer <= 0){
            hasDrinkenCoffee = false;
            coffeeTimer = 0;
            speed = 3.5f;
        }
    }
}
