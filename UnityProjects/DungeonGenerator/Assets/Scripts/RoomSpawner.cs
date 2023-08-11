using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] private int openingDirection; 
        //1 --> Need bottom Door
        //2 --> Need Top Door
        //3 --> Need Left Door
        //4 --> Need Right Door

        private RoomTemplates templates;
        private int roomRoll;
        [SerializeField] private bool jobDone = false;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.5f);
    }


    void Spawn()
    {
        if(!jobDone)
        {
            GameObject spawnedRoom;
            switch(openingDirection)
            {
                
                case 1:
                    //Spawn a room with a BOTTOM door

                    roomRoll = Random.Range(0, templates.bottomRooms.Length);
                    spawnedRoom = Instantiate(templates.bottomRooms[roomRoll]);
                    spawnedRoom.transform.position = transform.position;
                    break;

                case 2:
                    //Spawn a room with a TOP door

                    roomRoll = Random.Range(0, templates.topRooms.Length);
                    spawnedRoom = Instantiate(templates.topRooms[roomRoll]);
                    spawnedRoom.transform.position = transform.position;
                    break;

                case 3:
                    //Sapwn a room with a LEFT door

                    roomRoll = Random.Range(0, templates.leftRooms.Length);
                    spawnedRoom = Instantiate(templates.leftRooms[roomRoll]);
                    spawnedRoom.transform.position = transform.position;
                    break;

                case 4:
                    //Spawn a room with a RIGHT door

                    roomRoll = Random.Range(0, templates.rightRooms.Length);
                    spawnedRoom = Instantiate(templates.rightRooms[roomRoll]);
                    spawnedRoom.transform.position = transform.position;
                    break;
            }

            jobDone = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().jobDone == true)
        {
            Destroy(gameObject);
        }
    }
}
