using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] private int doorLocation;
    //1 = top
    //2 = right
    //3 = bottom
    //4 = left

    [SerializeField] private RoomTemplates templates;
    [SerializeField] private int roomRoll;


    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Templates").GetComponent<RoomTemplates>();
        SpawnRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRoom()
    {
        GameObject spawnedRoom;

        switch(doorLocation)
        {
            case 1:
                roomRoll = Random.Range(0, templates.topRooms.Length);
                spawnedRoom = Instantiate(templates.topRooms[roomRoll]);
                spawnedRoom.transform.position = transform.position;
                break;

            case 2:
                roomRoll = Random.Range(0, templates.rightRooms.Length);
                spawnedRoom = Instantiate(templates.rightRooms[roomRoll]);
                spawnedRoom.transform.position = transform.position;
                break;

            case 3:
                roomRoll = Random.Range(0, templates.bottomRooms.Length);
                spawnedRoom = Instantiate(templates.bottomRooms[roomRoll]);
                spawnedRoom.transform.position = transform.position;
                break;

            case 4:
                roomRoll = Random.Range(0, templates.leftRooms.Length);
                spawnedRoom = Instantiate(templates.leftRooms[roomRoll]);
                spawnedRoom.transform.position = transform.position;
                break;
        }
    }
}
