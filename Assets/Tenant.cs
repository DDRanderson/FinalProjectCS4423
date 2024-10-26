using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Tenant : MonoBehaviour
{
    Vector3 startingPosition;
    Vector3 targetPosition;
    public bool isInOffice = false;

    // Start is called before the first frame update
    void Start()
    {
        //subscribe to Player CollectRent event
        FindObjectOfType<Player>().collectRentEvent += MoveFromOffice;

        startingPosition = new Vector3(-8.33f,6,0);
        targetPosition = new Vector3(-8.33f,-2.5f,0);
        transform.position = startingPosition;
        StartCoroutine(MoveToOffice());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == targetPosition){
            isInOffice = true;
        }
        else {
            isInOffice = false;
        }
    }

    IEnumerator MoveToOffice(){
        
        while(/*transform.position != targetPosition*/ true){
            //yield return null;
            //transform.localPosition += new Vector3(0,-1,0);

            //randomly move to office once every 10-20 seconds
            yield return new WaitForSeconds(Random.Range(10,20));
            transform.position = targetPosition;
        }
         
    }

    void MoveFromOffice(){
        transform.position = startingPosition;
    }
}
