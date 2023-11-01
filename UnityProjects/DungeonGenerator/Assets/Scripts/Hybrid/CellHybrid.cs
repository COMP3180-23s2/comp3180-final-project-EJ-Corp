using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHybrid : MonoBehaviour
{
    [SerializeField] public Vector2 gridPosition;
    public bool taken = false;
    public bool hasRoom = false;
    [SerializeField] private Material takenMaterial;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(int x, int z)
    {
        gridPosition.x = x;
        gridPosition.y = z;
    }

    public CellHybrid DoMiddleCheck(Vector2 middlePos)
    {
        if(middlePos == gridPosition)
        {
            return this;
        }
        return null;
    }

    public void Occupy()
    {
        taken = true;
        transform.GetComponent<MeshRenderer>().material = takenMaterial;
    }
    
    public void LogRoom()
    {
        hasRoom = true;
    }

    public bool LookForNeighbourRooms(int originPos, GridGen grid)
    {
        Vector2 placeToCheck;
        if(originPos == 1) //Room Originated from Top
        {
            for(int i = 0; i < 3; i++)
            {
                if(i == 0) //Check Right side
                {
                    placeToCheck = gridPosition + new Vector2(1, 0);

                    if(placeToCheck.x < grid.width)
                    {
                        CellHybrid checkedCell = grid.FindCell(placeToCheck);
                        if(checkedCell.hasRoom) //Found room in neighbor
                        {
                            return true;
                        }
                    }
                } else if(i == 1) //Check Bottom SIde
                {
                    placeToCheck = gridPosition + new Vector2(0, -1);

                    if(placeToCheck.y >= 0)
                    {
                        CellHybrid checkedCell = grid.FindCell(placeToCheck);
                        if(checkedCell.hasRoom) //Found room in neighbor
                        {
                            return true;
                        }
                    }
                } else if(i == 2) //Check Left side
                {
                    placeToCheck = gridPosition + new Vector2(-1, 0);

                    if(placeToCheck.x >= 0)
                    {
                        CellHybrid checkedCell = grid.FindCell(placeToCheck);
                        if(checkedCell.hasRoom) //Found room in neighbor
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        } else if(originPos == 2) // Room Generated from right side
        {
            for(int i = 0; i < 3; i++)
            {
                if(i == 0) //Check Bottom side
                {
                    placeToCheck = gridPosition + new Vector2(0, -1);

                    if(placeToCheck.y >= 0)
                    {
                        CellHybrid checkedCell = grid.FindCell(placeToCheck);
                        if(checkedCell.hasRoom) //Found room in neighbor
                        {
                            return true;
                        }
                    }
                } else if(i == 1) //Check Left SIde
                {
                    placeToCheck = gridPosition + new Vector2(-1, 0);

                    if(placeToCheck.x >= 0)
                    {
                        CellHybrid checkedCell = grid.FindCell(placeToCheck);
                        if(checkedCell.hasRoom) //Found room in neighbor
                        {
                            return true;
                        }
                    }
                } else if(i == 2) //Check Top side
                {
                    placeToCheck = gridPosition + new Vector2(0, 1);

                    if(placeToCheck.y < grid.height)
                    {
                        CellHybrid checkedCell = grid.FindCell(placeToCheck);
                        if(checkedCell.hasRoom) //Found room in neighbor
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        } else if(originPos == 3) //Room Generated from Bottom side
        {
             for(int i = 0; i < 3; i++)
            {
                if(i == 0) //Check Left side
                {
                    placeToCheck = gridPosition + new Vector2(-1, 0);

                    if(placeToCheck.x >= 0)
                    {
                        CellHybrid checkedCell = grid.FindCell(placeToCheck);
                        if(checkedCell.hasRoom) //Found room in neighbor
                        {
                            return true;
                        }
                    }
                    
                } else if(i == 1) //Check Top SIde
                {
                    placeToCheck = gridPosition + new Vector2(0, 1);

                    if(placeToCheck.y < grid.height)
                    {
                        CellHybrid checkedCell = grid.FindCell(placeToCheck);
                        if(checkedCell.hasRoom) //Found room in neighbor
                        {
                            return true;
                        }
                    }
                    
                } else if(i == 2) //Check Right side
                {
                    placeToCheck = gridPosition + new Vector2(1, 0);

                    if(placeToCheck.x < grid.width)
                    {
                        CellHybrid checkedCell = grid.FindCell(placeToCheck);
                        if(checkedCell.hasRoom) //Found room in neighbor
                        {
                            return true;
                        }
                    }
                    
                }
            }
            return false;
        } else if(originPos == 4) //Room generated from Left side
        {
            for(int i = 0; i < 3; i++)
            {
                if(i == 0) //Check Top side
                {
                    placeToCheck = gridPosition + new Vector2(0, 1);

                    if(placeToCheck.y < grid.height)
                    {
                        CellHybrid checkedCell = grid.FindCell(placeToCheck);
                        if(checkedCell.hasRoom) //Found room in neighbor
                        {
                            return true;
                        }
                    }
                } else if(i == 1) //Check Right SIde
                {
                    placeToCheck = gridPosition + new Vector2(1, 0);

                    if(placeToCheck.x < grid.width)
                    {
                        CellHybrid checkedCell = grid.FindCell(placeToCheck);
                        if(checkedCell.hasRoom) //Found room in neighbor
                        {
                            return true;
                        }
                    }
                } else if(i == 2) //Check Bottom side
                {
                    placeToCheck = gridPosition + new Vector2(0, -1);

                    if(placeToCheck.y >= 0)
                    {
                        CellHybrid checkedCell = grid.FindCell(placeToCheck);
                        if(checkedCell.hasRoom) //Found room in neighbor
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        return false;
    }
}
