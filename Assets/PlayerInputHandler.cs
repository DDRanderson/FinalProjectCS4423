using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Tenant tenant;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			if (tenant.isInOffice && player.isBehindDesk)
			{
				player.CollectRentTrigger();
			}
		}
	}

    // FixedUpdate is called once every 0.02 seconds
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement += new Vector3(0,1,0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement += new Vector3(0,-1,0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement += new Vector3(-1,0,0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement += new Vector3(1,0,0);
        }
        player.Movement(movement);

    }

}
