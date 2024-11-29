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

    int moveToOfficeCountdown;

    // Start is called before the first frame update
    void Start()
    {
        //subscribe to Player CollectRent event
        FindObjectOfType<Player>().collectRentEvent += RentCollected;

        FindObjectOfType<TimeManager>().oneSecondEvent += OneSecondListenEvent;

        moveToOfficeCountdown = Random.Range(10,20);

        startingPosition = new Vector3(-8.33f,6,0);
        targetPosition = new Vector3(-8.33f,-2.5f,0);
        transform.position = startingPosition;
        //StartCoroutine(MoveCheck());
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

    IEnumerator MoveCheck(){
        
        while(/*transform.position != targetPosition*/ true){
            //yield return null;
            //transform.localPosition += new Vector3(0,-1,0);

            //randomly move to office once every number of seconds in random range
            /*  TODO: wait timer keeps retriggering, even after
                tenant moves to office. need to set it to where the 
                timer waits to start counting down again until after
                rent is collected. maybe call the oneSecondTimer trigger
                event to start counting up internally?
            */
            yield return new WaitForSeconds(Random.Range(10,20));
            MoveToOffice();
        }
         
    }

    void MoveToOffice(){
        transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime);
        if(transform.position.y < targetPosition.y){
            transform.position = new Vector2(transform.position.x, targetPosition.y);
            isMovingToOffice = false;
            isInOffice = true;
        }
    }

    void MoveFromOffice(){
        transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime);
        if(transform.position.y > startingPosition.y){
            transform.position = new Vector2(transform.position.x, startingPosition.y);
            isLeavingOffice = false;
            moveToOfficeCountdown = Random.Range(10,20);
        }
    }

    void OneSecondListenEvent(){
        if(moveToOfficeCountdown > 0){
            moveToOfficeCountdown--;
        }

        if(moveToOfficeCountdown == 0){
            isMovingToOffice = true;
            moveToOfficeCountdown = -1;
        }        
    }

    void RentCollected(){
        isLeavingOffice = true;
        isInOffice = false;
    }
}
