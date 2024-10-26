using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public delegate void PlayerEvents();
    public event PlayerEvents collectRentEvent;

    [SerializeField] Tenant tenant;

    [Header("Movement")]
    [SerializeField] float speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.R) && tenant.isInOffice == true){
            Debug.Log("Money Collected");
            CollectRentTrigger();
        }*/

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

    void OnTriggerStay2D(Collider2D collision){
        if(collision.CompareTag("BehindDesk")){
            if(Input.GetKey(KeyCode.R) && tenant.isInOffice == true){
                CollectRentTrigger();
            }
        }
    }
}
