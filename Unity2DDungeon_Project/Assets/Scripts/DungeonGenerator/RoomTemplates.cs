using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{    
    public int mapSize;
    public bool firstGeneration;
    public GameObject[] firstBottomRooms;
    public GameObject[] firstTopRooms;
    public GameObject[] firstLeftRooms;
    public GameObject[] firstRightRooms;
    public GameObject[] lastBottomRooms;
    public GameObject[] lastTopRooms;
    public GameObject[] lastLeftRooms;
    public GameObject[] lastRightRooms;
    public GameObject closedRooms;
    public List<GameObject> rooms;
    private bool spawnedBoss;
    public GameObject boss;
    private int roomsCount;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        firstGeneration = true;
        roomsCount = 0;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        int currentRoomsCount = rooms.Count;
        if(rooms.Count >= mapSize) firstGeneration = false;
        if(!spawnedBoss && firstGeneration == false && currentRoomsCount == roomsCount){
            int i;
            Instantiate(boss, rooms[rooms.Count-1].transform.position, Quaternion.identity);
            spawnedBoss = true;
        }
        roomsCount = rooms.Count;
    }
}
