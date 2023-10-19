using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellularGrid : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private int density;

    [SerializeField] private Cell cellPrefab;
    [SerializeField] private List<Cell> cells;

    [SerializeField] private bool redyForStates;
    [SerializeField] private bool checkedStates;
    private float waitTime;

    private int iterations;

    void Start()
    {
        GenerateGrid();
        GetNeighbours();
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            GoNextState();
        }

        if(waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }

        if(waitTime <= 0)
        {
            redyForStates = true;
        }
        if(redyForStates && !checkedStates)
        {
            CheckStates();
        }
    }

    public void GenerateGrid()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                int tileRoll = Random.Range(1, 101);
                if(tileRoll > density)
                {
                    Cell cellSpawned = Instantiate(cellPrefab);
                    cellSpawned.transform.position = new Vector2(i, j);
                    cellSpawned.cellState = Cell.CellState.floor;
                    cells.Add(cellSpawned);
                } else 
                {
                    Cell cellSpawned = Instantiate(cellPrefab);
                    cellSpawned.transform.position = new Vector2(i, j);
                    cellSpawned.cellState = Cell.CellState.wall;
                    cells.Add(cellSpawned);
                }
                
            }
        }
    }

    public void GetNeighbours()
    {
        foreach(Cell currentCell in cells)
        {
            currentCell.DoNeighbourCheck();
            //currentCell.CheckNextState();
            //currentCell.checkHolder.SetActive(false);
        }
        waitTime = 1;
    }

    public void CheckStates()
    {
        foreach(Cell currentCell in cells)
        {
            currentCell.CheckNextState();
            //currentCell.checkHolder.SetActive(false);
            redyForStates = false;
            checkedStates = true;
        }
        
    }

    public void GoNextState()
    {
        foreach(Cell currentCell in cells)
        {
            currentCell.cellState = currentCell.nextState;
            currentCell.ChangeState();
            currentCell.CheckNextState();
        }
        iterations++;
        Debug.Log("Iteration Number: " + iterations);
    }
}
