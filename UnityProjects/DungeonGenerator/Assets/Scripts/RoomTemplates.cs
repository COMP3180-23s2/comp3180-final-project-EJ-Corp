using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    [SerializeField] public GameObject[] bottomRooms;
    [SerializeField] public GameObject[] topRooms;
    [SerializeField] public GameObject[] leftRooms;
    [SerializeField] public GameObject[] rightRooms;

    [SerializeField] private GameObject startingRoomPrefab;
    [SerializeField] private GameObject rooms;
    // Start is called before the first frame update
    void Start()
    {
        rooms = GameObject.FindGameObjectWithTag("Holder");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Destroy(rooms);
            
            rooms = Instantiate(startingRoomPrefab);
        }
    }
}
