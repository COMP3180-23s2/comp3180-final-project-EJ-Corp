using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridGen : MonoBehaviour
{
    [SerializeField] private CellHybrid spawnPoints;
    [SerializeField] private RoomHandler spawnRoomPrefab;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private int spreadOffset;
    [SerializeField] private CellHybrid middleCell;
    

    
    void Awake()
    {
        GenerateGrid();
    }

    void Start()
    {
        SpawnFirstRoom();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGrid()
    {
        Vector2 middlePos = new Vector2(width/2, height/2);
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                Vector3 currentPos = new Vector3(i * spreadOffset, 1, j * spreadOffset);
                CellHybrid spawnPoint = Instantiate(spawnPoints);
                spawnPoint.transform.position = currentPos;
                spawnPoint.SetPosition(i, j);
                if(i == middlePos.x && j == middlePos.y)
                {
                    middleCell = spawnPoint;
                }
            }
        }
    }

    public void SpawnFirstRoom()
    {
        RoomHandler spawnRoom = Instantiate(spawnRoomPrefab);
        spawnRoom.transform.position = middleCell.transform.position - new Vector3(0, 1, 0);
        spawnRoom.SetRoomCell(middleCell);
    }
}
