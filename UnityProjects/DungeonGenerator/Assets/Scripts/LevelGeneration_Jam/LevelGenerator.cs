using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int columns;
    [SerializeField] private int rows;
    [SerializeField] private int rooms;
    [SerializeField] private GameObject spawnPointPrefab;
    [SerializeField] private Vector3 spaceOffset;
    [SerializeField] private Transform currentPos;
    [SerializeField] private float zOffset;

    [SerializeField] private List<RoomGenerator> possibleRooms;
    [SerializeField] private List<RoomGenerator> roomLocations;
    void Start()
    {
        GenerateLevel();
        GenerateRooms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateLevel()
    {
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                GameObject spawnPoint = Instantiate(spawnPointPrefab);
                spawnPoint.transform.position = currentPos.position;
                currentPos.position += spaceOffset;
                possibleRooms.Add(spawnPoint.GetComponent<RoomGenerator>());
            }
            currentPos.position = new Vector3(0, 0, zOffset * i + (zOffset));
        }
    }

    public void GenerateRooms()
    {
        for(int i = 0; i < rooms; i++)
        {
            int positionRoll = Random.Range(0, possibleRooms.Count);
            roomLocations.Add(possibleRooms[positionRoll]);
            possibleRooms.Remove(possibleRooms[positionRoll]);
        }

        foreach(RoomGenerator room in roomLocations)
        {
            room.Spawn();
        }
    }
}
