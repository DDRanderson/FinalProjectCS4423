using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Tenant : MonoBehaviour
{
    Vector3 startingPosition;
    Vector3 targetPosition;
    public bool isInOffice = false;
    public bool isMovingToOffice = false;
    public bool isLeavingOffice = false;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public int currSpriteIndex;
    public int newSpriteIndex;
    public int moveMin;
    public int moveMax;
    

    public int moveToOfficeCountdown;

    // Start is called before the first frame update
    void Start()
    {
        moveMin = 8;
        moveMax = 12;
        //subscribe to Player CollectRent event
        FindObjectOfType<Player>().collectRentEvent += RentCollected;

        FindObjectOfType<TimeManager>().oneSecondEvent += OneSecondListenEvent;
        FindObjectOfType<TimeManager>().endOfDayEvent += EndOfDayEvent;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        currSpriteIndex = -1;
        newSpriteIndex = 0;

        moveToOfficeCountdown = Random.Range(moveMin,moveMax);

        startingPosition = new Vector3(-8.33f,6,0);
        targetPosition = new Vector3(-8.33f,-2.5f,0);
        transform.position = startingPosition;

    }

    // Update is called once per frame
    void Update()
    {

        if (isMovingToOffice){
            MoveToOffice();
        }

        if (isLeavingOffice){
            MoveFromOffice();
        }

    }


    void MoveToOffice(){
        transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime);
        if(transform.position.y < targetPosition.y){
            transform.position = new Vector2(transform.position.x, targetPosition.y);
            isMovingToOffice = false;
            isInOffice = true;
            /* TODO: play voice clip for when tenant is ready to pay */
        }
    }

    void MoveFromOffice(){
        transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime);
        if(transform.position.y > startingPosition.y){
            transform.position = new Vector2(transform.position.x, startingPosition.y);
            isLeavingOffice = false;
            moveToOfficeCountdown = Random.Range(moveMin,moveMax);
        }
    }

    void OneSecondListenEvent(){
        if(moveToOfficeCountdown > 0){
            moveToOfficeCountdown--;
        }

        //trigger for moving to the office
        if(moveToOfficeCountdown == 0){
            isMovingToOffice = true;
            ChangeSprite();
            moveToOfficeCountdown = -1;
        }        
    }

    void RentCollected(){
        isLeavingOffice = true;
        isInOffice = false;
        /* TODO: play voice clip of specific tenant that rent is collected from */
    }

    void ChangeSprite(){
        //randomly changes to a new tenant sprite, checks to ensure non-consecutive tenant sprites are chosen
        newSpriteIndex = Random.Range(0,spriteArray.Length);
        if (currSpriteIndex == -1){
            currSpriteIndex = newSpriteIndex;
            spriteRenderer.sprite = spriteArray[newSpriteIndex]; 
        }
        else if (newSpriteIndex == currSpriteIndex){
            while (newSpriteIndex == currSpriteIndex){
                newSpriteIndex = Random.Range(0,spriteArray.Length);
            }
            currSpriteIndex = newSpriteIndex;
            spriteRenderer.sprite = spriteArray[newSpriteIndex];
        }
        else {
            currSpriteIndex = newSpriteIndex;
            spriteRenderer.sprite = spriteArray[newSpriteIndex];
        }
    }

    void EndOfDayEvent(){
        transform.position = startingPosition;
        isMovingToOffice = false;
        isLeavingOffice = false;
        isInOffice = false;
        moveToOfficeCountdown = Random.Range(moveMin,moveMax);
    }
}
