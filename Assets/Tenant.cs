using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Tenant : MonoBehaviour
{
    Vector3 startingPosition;
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = new Vector3(-8.33f,6,0);
        targetPosition = new Vector3(-8.33f,-2.5f,0);
        transform.position = startingPosition;
        StartCoroutine(MoveToOffice());
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    IEnumerator MoveToOffice(){
        
        while(transform.position != targetPosition){
            transform.localPosition += new Vector3(0,-1,0);
            yield return null;
        }
         
    }
}
