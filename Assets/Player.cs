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
	
	public bool isBehindDesk = false;

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

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("BehindDesk")){
			isBehindDesk = true;
        }
    }
	
	void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("BehindDesk")){
			isBehindDesk = false;
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
}
