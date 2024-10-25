using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] Player player;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate is called once every 0.02 seconds
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.W))
        {
            movement += new Vector3(0,1,0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += new Vector3(0,-1,0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += new Vector3(-1,0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += new Vector3(1,0,0);
        }
        player.Movement(movement);

    }

}
