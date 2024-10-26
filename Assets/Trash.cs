using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public delegate void trashEvents();
    public event trashEvents TrashDestroyed;

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
                //TrashDestroyedTrigger();
            }
        }
    }

    void TrashDestroyedTrigger(){
        TrashDestroyed?.Invoke();
    }
}
