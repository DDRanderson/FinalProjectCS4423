using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{

    public Trash trash;
    public float radius = 1;
    public int percentChance = 10;

    //an array of Vector2D locations to move to 
    List<Vector2> locationsList = new List<Vector2>(); 


    void Start()
    {
        PopulateLocationsList();
        
        //subscribe to oneSecondTrigger event
        FindObjectOfType<TimeManager>().oneSecondEvent += SpawnObjectRandomly;
        //FindObjectOfType<Trash>().TrashDestroyed += UpdateTrashCount;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)){
            SpawnObject();
        }*/
    }

    void SpawnObject(){
        Vector3 randomPos = Random.insideUnitCircle * radius;

        Instantiate(trash, transform.position + randomPos, Quaternion.identity);
    }

    void SpawnObjectRandomly(){
        //move the spawner to a random location in the locations list
        int randLoc = Random.Range(0,locationsList.Count-1);
        transform.localPosition = locationsList[randLoc];

        //percentage chance of a trash spawning
        int rand = Random.Range(0,100);
        //Debug.Log("Random Trash Spawn Number: " + rand);
        
        if(rand <= percentChance){
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(trash, transform.position + randomPos, Quaternion.identity);
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

    void PopulateLocationsList(){
        for(float i = -4.5f; i <= 7.5f; i++){ //
            locationsList.Add(new Vector2(i,0));
            locationsList.Add(new Vector2(i,4.25f));
            locationsList.Add(new Vector2(i,-4));
        }
    }

    void UpdateTrashCount(){
        
        
    }

}
