using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Tenant tenant;

    public bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
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

        if(Input.GetKeyDown(KeyCode.Escape)){
            if (!isPaused){
                PauseGame();
                isPaused = true;
                return;
            }

            if (isPaused){
                ResumeGame();
                isPaused = false;
                return;
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

    void PauseGame(){
        Time.timeScale = 0;
    }

    void ResumeGame(){
        Time.timeScale = 1;
    }

}
