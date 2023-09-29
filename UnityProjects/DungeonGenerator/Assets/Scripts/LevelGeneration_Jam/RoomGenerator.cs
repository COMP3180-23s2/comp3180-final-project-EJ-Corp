using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] private RoomTemplates3D templates;
    [SerializeField] private int roomRoll;
    // Start is called before the first frame update
    void Awake()
    {
        templates = GameObject.FindGameObjectWithTag("Templates").GetComponent<RoomTemplates3D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        roomRoll = Random.Range(0, templates.allRooms.Length);
        GameObject spawnedRoom = Instantiate(templates.allRooms[roomRoll]);
        spawnedRoom.transform.position = transform.position;
    }
}
