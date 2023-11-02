using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GridGen : MonoBehaviour
{
    [SerializeField] private CellHybrid spawnPoints;
    [SerializeField] private RoomHandler spawnRoomPrefab;
    [SerializeField] public int width;
    [SerializeField] public int height;
    [SerializeField] private int spreadOffset;
    [SerializeField] private CellHybrid middleCell;
    [SerializeField] private List<CellHybrid> cellCollection;
    [SerializeField] public RoomHandler spawnRoom;

    public List<RoomHandler> roomCollection;

    private bool newLevel;
    [SerializeField] private GameObject cells;
    

    
    void Awake()
    {
        GenerateGrid();
    }

    void Start()
    {
        SpawnFirstRoom();
        spawnRoom.ChoosePath();
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            // foreach(RoomHandler room in roomCollection)
            // {
            //     Destroy(room.gameObject);
            // }

            // foreach(Transform child in cells.transform)
            // {
            //     Destroy(child.gameObject);
            // }

            // GenerateGrid();
            // SpawnFirstRoom();
            // newLevel = true;
            Scene scene = SceneManager.GetActiveScene();

            SceneManager.LoadScene(scene.name);
        }
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
                spawnPoint.transform.parent = cells.transform;
                spawnPoint.SetPosition(i, j);
                cellCollection.Add(spawnPoint);
                spawnPoint.name = i + "," + j;
                if(i == middlePos.x && j == middlePos.y)
                {
                    middleCell = spawnPoint;
                }

                spawnPoint.taken = false;
                spawnPoint.hasRoom = false;
            }
        }
    }

    public void SpawnFirstRoom()
    {
        spawnRoom = Instantiate(spawnRoomPrefab);
        spawnRoom.transform.position = middleCell.transform.position - new Vector3(0, 1, 0);
        spawnRoom.SetRoomCell(middleCell);
        spawnRoom.SetGrid(this);
        roomCollection.Add(spawnRoom);
        
    }

    public CellHybrid FindCell(Vector2 position)
    {
        //Debug.Log("Finding Cell: " + position);
        foreach(CellHybrid cell in cellCollection)
        {
            if(cell.gridPosition == position)
            {
                return cell;
            }
        }
        Debug.Log("NotFound: " + position);
        return null;
    }

    public int GetGridWidth()
    {
        return width;
    }

    public int GetGridHeight()
    {
        return height;
    }
}
