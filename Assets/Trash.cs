using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if(Input.GetKey(KeyCode.E)){
                Destroy(gameObject);
            }
        }
    }
}
