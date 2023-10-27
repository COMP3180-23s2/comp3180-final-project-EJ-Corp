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
    [SerializeField] private bool isSpawn = false;
    
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
        if(doors.Count <= 0)
        {
            // if(isSpawn && doors.Count <= 0)
            // {
            //     return;
            // }
            // grid.Spaw
            return;
        }
        int pathChosen = Random.Range(0, doors.Count);

        pathChosen = 0;


        if(doors[pathChosen] == 1) //Has a door at the top ---> Pull room from BOTTOM List
        {
            //Check Same x but Y +1
            Vector2 positionToCheck = new Vector2(roomCell.gridPosition.x, roomCell.gridPosition.y + 1);

            //if position to check is outside boundaries (x > || < width) || (y > || < height) ---> spawn door and return
            if(positionToCheck.y < 0 || positionToCheck.y >= grid.GetGridHeight())
            {
                SpawnDoor(1);
                return;
            }

            CellHybrid cellToCheck = grid.FindCell(positionToCheck);

            if(cellToCheck.taken)
            {
                SpawnDoor(1); //Spawn a door on pos 1 == TOP
                
            } else if(cellToCheck.taken == false)
            {
                if(cellToCheck.LookForNeighbourRooms(3, grid))
                {
                    SpawnDoor(1);
                    cellToCheck.Occupy();
                } else {
                    SpawnRoom(3, cellToCheck); //Spawn room from bottom pool (pool 3)
                }
                
            }
            
        } else if(doors[pathChosen] == 2) //Has a door at the right ---> Pull room from LEFT List
        {
            //Check x + 1 but same Y
            Vector2 positionToCheck = new Vector2(roomCell.gridPosition.x + 1, roomCell.gridPosition.y);

            if(positionToCheck.x < 0 || positionToCheck.x >= grid.GetGridWidth())
            {
                SpawnDoor(2);
                return;
            }

            CellHybrid cellToCheck = grid.FindCell(positionToCheck);

            if(cellToCheck.taken)
            {
                SpawnDoor(2); //Spawn a door on pos 2 == RIGHT
                
            } else 
            {
                SpawnRoom(4, cellToCheck); //Spawn room from left pool (pool 4)
                
            }

        } else if(doors[pathChosen] == 3) //Has a door at the bottom ---> Pull room from TOP List
        {
            //Check same x but Y -1
            Vector2 positionToCheck = new Vector2(roomCell.gridPosition.x, roomCell.gridPosition.y - 1);

            if(positionToCheck.y < 0 || positionToCheck.y >= grid.GetGridHeight())
            {
                SpawnDoor(3);
                return;
            }

            CellHybrid cellToCheck = grid.FindCell(positionToCheck);

            if(cellToCheck.taken)
            {
                SpawnDoor(3); //Spawn a door on pos 3 == BOTTOM
                
            } else if(cellToCheck.taken == false)
            {
                if(cellToCheck.LookForNeighbourRooms(1, grid))
                {
                    SpawnDoor(3);
                    cellToCheck.Occupy();
                } else 
                {
                    SpawnRoom(1, cellToCheck); //Spawn room from Top pool (pool 1)
                }   
                
                
            }
        } else if(doors[pathChosen] == 4) //Has a door at the Left ---> Pull room from RIGHT List
        {
            //Check x - 1 but same Y
            Vector2 positionToCheck = new Vector2(roomCell.gridPosition.x - 1, roomCell.gridPosition.y);

            if(positionToCheck.x < 0 || positionToCheck.x >= grid.GetGridWidth())
            {
                SpawnDoor(4);
                return;
            }

            CellHybrid cellToCheck = grid.FindCell(positionToCheck);

            if(cellToCheck.taken)
            {
                SpawnDoor(4); //Spawn a door on pos 2 == LEFT
                
            } else 
            {
                SpawnRoom(2, cellToCheck); //Spawn room from Right pool (pool 2)
                
            }
        }
        
    }

    public void SetRoomCell(CellHybrid cell)
    {
        roomCell = cell;
        roomCell.Occupy();
        roomCell.LogRoom();
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

        } else if(pos == 2)
        {
            GameObject door = Instantiate(vertDoor);
            door.transform.position = transform.position + new Vector3(9.5f, 2.5f, 0);
            door.transform.parent = transform;

        } else if(pos == 3)
        {
            GameObject door = Instantiate(horiDoor);
            door.transform.position = transform.position + new Vector3(0, 2.5f, -9.5f);
            door.transform.parent = transform;

        } else if(pos == 4)
        {
            GameObject door = Instantiate(vertDoor);
            door.transform.position = transform.position + new Vector3(-9.5f, 2.5f, 0);
            door.transform.parent = transform;
        }
    }

    public void SpawnRoom(int doorNeeded, CellHybrid cellPosition)
    {
        int roomRoll = Random.Range(0, 4);
        if(doorNeeded == 1) //Top Pool (Room has door on top side)
        {
            RoomHandler newRoom = Instantiate(TemplateRooms.Templates.topRooms[roomRoll]);
            newRoom.transform.position = cellPosition.transform.position - new Vector3(0, 1, 0);
            newRoom.SetRoomCell(cellPosition);
            cellPosition.Occupy();
            newRoom.OccupyWallNeighbors();

            DoorDone(3);
            newRoom.DoorDone(1);
            newRoom.ChoosePath();
            newRoom.roomCell.LogRoom();

        } else if(doorNeeded == 2) //Right Pool (Room has door on right side)
        {
            RoomHandler newRoom = Instantiate(TemplateRooms.Templates.rightRooms[roomRoll]);
            newRoom.transform.position = cellPosition.transform.position - new Vector3(0, 1, 0);
            newRoom.SetRoomCell(cellPosition);
            cellPosition.Occupy();
            newRoom.OccupyWallNeighbors();

            DoorDone(4);
            newRoom.DoorDone(2);
            newRoom.ChoosePath();

        } else if(doorNeeded == 3) //Bottom Pool (Room has door on bottom side)
        {
            RoomHandler newRoom = Instantiate(TemplateRooms.Templates.bottomRooms[roomRoll]);
            newRoom.transform.position = cellPosition.transform.position - new Vector3(0, 1, 0);
            newRoom.SetRoomCell(cellPosition);
            cellPosition.Occupy();
            newRoom.OccupyWallNeighbors();

            DoorDone(1);
            newRoom.DoorDone(3);
            newRoom.ChoosePath();

        } else if(doorNeeded == 4) //Left Pool (Room has a door on left side)
        {
            RoomHandler newRoom = Instantiate(TemplateRooms.Templates.leftRooms[roomRoll]);
            newRoom.transform.position = cellPosition.transform.position - new Vector3(0, 1, 0);
            newRoom.SetRoomCell(cellPosition);
            cellPosition.Occupy();
            newRoom.OccupyWallNeighbors();

            DoorDone(2);
            newRoom.DoorDone(4);
            newRoom.ChoosePath();
        }

        
    }

    public void OccupyWallNeighbors()
    {
        foreach(int wall in walls)
        {
            if(wall == 1) //Occupy one above
            {
                Vector2 positionToOccupy = new Vector2(roomCell.gridPosition.x, roomCell.gridPosition.y + 1);

                //if position to check is outside boundaries (x > || < width) || (y > || < height) ---> do nothing for this wall
                // if(positionToOccupy.x > width || positionToOccupy.x < width)
                // {
                    
                // }

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
