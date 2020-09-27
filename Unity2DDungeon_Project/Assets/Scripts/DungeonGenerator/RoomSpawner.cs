using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    private RoomTemplates templates;
    private bool isFirstGeneration;
    private int rand;
    private bool spawned;
    public float waitTime = 4f;

    private void Start() {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.3f);
    }

    // Update is called once per frame
    void Spawn()
    {
        isFirstGeneration = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>().firstGeneration;
        if(spawned == false){
            if(openingDirection == 1){
            // Spawning BOTTOM room
            if(isFirstGeneration == true){
                rand = Random.Range(0, templates.firstBottomRooms.Length);
                Instantiate(templates.firstBottomRooms[rand], transform.position, templates.firstBottomRooms[rand].transform.rotation);
            }else{
                rand = Random.Range(0, templates.lastBottomRooms.Length);
                Instantiate(templates.lastBottomRooms[rand], transform.position, templates.lastBottomRooms[rand].transform.rotation);
            }
            
            } else if(openingDirection ==2){
                // Spawning TOP room
                if(isFirstGeneration == true){
                rand = Random.Range(0, templates.firstTopRooms.Length);
                Instantiate(templates.firstTopRooms[rand], transform.position, templates.firstTopRooms[rand].transform.rotation);
                }else{
                    rand = Random.Range(0, templates.lastTopRooms.Length);
                    Instantiate(templates.lastTopRooms[rand], transform.position, templates.lastTopRooms[rand].transform.rotation);
                }
            
            } else if(openingDirection ==3){
                // Spawning LEFT room
                if(isFirstGeneration == true){
                rand = Random.Range(0, templates.firstLeftRooms.Length);
                Instantiate(templates.firstLeftRooms[rand], transform.position, templates.firstLeftRooms[rand].transform.rotation);
                }else{
                    rand = Random.Range(0, templates.lastLeftRooms.Length);
                    Instantiate(templates.lastLeftRooms[rand], transform.position, templates.lastLeftRooms[rand].transform.rotation);
                }

            } else if(openingDirection ==4){
                // Spawning RIGHT room
                if(isFirstGeneration == true){
                rand = Random.Range(0, templates.firstRightRooms.Length);
                Instantiate(templates.firstRightRooms[rand], transform.position, templates.firstRightRooms[rand].transform.rotation);
                }else{
                    rand = Random.Range(0, templates.lastRightRooms.Length);
                    Instantiate(templates.lastRightRooms[rand], transform.position, templates.lastRightRooms[rand].transform.rotation);
                }
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("SpawnPoint")){
            try
            {
                if (!other.GetComponent<RoomSpawner>().spawned && !spawned)
                {
                    Instantiate(templates.closedRooms, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
            catch (System.Exception e)
            {
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
