using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    [SerializeField] private GameObject horiDoor;
    [SerializeField] private GameObject vertDoor;
    [SerializeField] private List<int> doors;
        //Door 1 = Top
        //Door 2 = Right
        //Door 3 = Bottom
        //Door 4 = Left

    [SerializeField] private CellHybrid roomCell;
    [SerializeField] private GridGen grid;
    
    void Start()
    {
        
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
                SpawnDoor(1); //Spawn a door on pos 1 == TOP
            } else 
            {
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
            GameObject newRoom = Instantiate(TemplateRooms.Templates.bottomRooms[roomRoll]);
            newRoom.transform.position = cellPosition.transform.position - new Vector3(0, 1, 0);
            cellPosition.Occupy();
        }
    }
}
