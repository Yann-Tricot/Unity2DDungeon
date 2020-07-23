using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    private RoomTemplates templates;
    private int rand;
    private bool spawned;
    public float waitTime = 4f;

    private void Start() {
        Destroy(gameObject, waitTime);
        templates= GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.3f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if(spawned == false){
            if(openingDirection == 1){
            // Spawning BOTTOM room
            rand = Random.Range(0, templates.bottomRooms.Length);
            Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            } else if(openingDirection ==2){
                // Spawning TOP room
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            } else if(openingDirection ==3){
                // Spawning LEFT room
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            } else if(openingDirection ==4){
                // Spawning RIGHT room
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
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
