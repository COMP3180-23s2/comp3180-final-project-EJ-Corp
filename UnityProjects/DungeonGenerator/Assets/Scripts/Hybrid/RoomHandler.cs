using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    [Header("Manually Fill In")]
    [SerializeField] private GameObject horiDoor;
    [SerializeField] private GameObject vertDoor;
    [SerializeField] private List<int> doors, walls;
        //Door 1 = Top
        //Door 2 = Right
        //Door 3 = Bottom
        //Door 4 = Left

    [SerializeField] private CellHybrid roomCell;
    [SerializeField] private GridGen grid;
    
    void Awake()
    {
        grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridGen>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            ChoosePath();
        }
        if(Input.GetButtonDown("1"))
        {

        }
    }

    public void ChoosePath()
    {
        int pathChosen = Random.Range(0, doors.Count);

        pathChosen = 0;

        if(doors[pathChosen] == 1) //Has a door at the top ---> Pull room from BOTTOM List
        {
            //Check Same x but Y +1
            Vector2 positionToCheck = new Vector2(roomCell.gridPosition.x, roomCell.gridPosition.y + 1);
            CellHybrid cellToCheck = grid.FindCell(positionToCheck);

            if(cellToCheck.taken)
            {
                Debug.Log("Spaning Door");
                SpawnDoor(1); //Spawn a door on pos 1 == TOP
                
            } else 
            {
                Debug.Log("Spaning Room");
                SpawnRoom(3, cellToCheck); //Spawn room from bottom pool (pool 3)
                
            }
            
        } else if(doors[pathChosen] == 2) //Has a door at the right ---> Pull room from LEFT List
        {

        } else if(doors[pathChosen] == 3) //Has a door at the bottom ---> Pull room from TOP List
        {

        } else if(doors[pathChosen] == 4) //Has a door at the Left ---> Pull room from RIGHT List
        {

        }
        
    }

    public void SetRoomCell(CellHybrid cell)
    {
        roomCell = cell;
        roomCell.Occupy();
    }

    public void SetGrid(GridGen generatedGrid)
    {
        grid = generatedGrid;
    }

    public void DoorDone(int doorID)
    {
        doors.Remove(doorID);
    }

    public void SpawnDoor(int pos)
    {
        if(pos == 1)
        {
            GameObject door = Instantiate(horiDoor);
            door.transform.position = transform.position + new Vector3(0, 2.5f, 9.5f);
            door.transform.parent = transform;
        }
    }

    public void SpawnRoom(int doorNeeded, CellHybrid cellPosition)
    {
        int roomRoll = Random.Range(0, 4);
        if(doorNeeded == 3)
        {
            RoomHandler newRoom = Instantiate(TemplateRooms.Templates.bottomRooms[roomRoll]);
            newRoom.transform.position = cellPosition.transform.position - new Vector3(0, 1, 0);
            newRoom.SetRoomCell(cellPosition);
            cellPosition.Occupy();
            newRoom.OccupyWallNeighbors();

            DoorDone(1);
            newRoom.DoorDone(3);
        }

        
    }

    public void OccupyWallNeighbors()
    {
        foreach(int wall in walls)
        {
            if(wall == 1) //Occupy one above
            {
                Vector2 positionToOccupy = new Vector2(roomCell.gridPosition.x, roomCell.gridPosition.y + 1);
                CellHybrid cellToOccupy = grid.FindCell(positionToOccupy);
                cellToOccupy.Occupy();

            } else if(wall == 2) //Occupy one right
            {
                Vector2 positionToOccupy = new Vector2(roomCell.gridPosition.x + 1, roomCell.gridPosition.y);
                CellHybrid cellToOccupy = grid.FindCell(positionToOccupy);
                cellToOccupy.Occupy();

            } else if(wall == 3) // occupy one below
            {
                Vector2 positionToOccupy = new Vector2(roomCell.gridPosition.x, roomCell.gridPosition.y - 1);
                CellHybrid cellToOccupy = grid.FindCell(positionToOccupy);
                cellToOccupy.Occupy();

            }else if(wall == 4) //Occupy one Left
            {
                Vector2 positionToOccupy = new Vector2(roomCell.gridPosition.x - 1, roomCell.gridPosition.y);
                CellHybrid cellToOccupy = grid.FindCell(positionToOccupy);
                cellToOccupy.Occupy();
            }
        }
    }
}
