using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{

    public GameObject trash;
    public float radius = 1;
    public int percentChance = 30;

    // Start is called before the first frame update
    void Start()
    {
        //subscribe to oneSecondTrigger event
        FindObjectOfType<TimeManager>().oneSecondEvent += SpawnObjectRandomly;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            SpawnObject();
        }
    }

    void SpawnObject(){
        Vector3 randomPos = Random.insideUnitCircle * radius;

        Instantiate(trash, transform.position + randomPos, Quaternion.identity);
    }

    void SpawnObjectRandomly(){
        //percentage chance of a trash spawning
        int rand = Random.Range(0,100);
        Debug.Log("Random Trash Spawn Number: " + rand);
        
        if(rand <= percentChance){
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(trash, transform.position + randomPos, Quaternion.identity);
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

}
