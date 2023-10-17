using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellularGrid : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private int density;

    [SerializeField] private Cell floorTile;
    [SerializeField] private Cell wallTile;
    [SerializeField] private List<Cell> cells;

    void Start()
    {
        GenerateGrid();
        GetNeighbours();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            GetNeighbours();
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
                    Cell cellSpawned = Instantiate(floorTile);
                    cellSpawned.transform.position = new Vector2(i, j);
                    cells.Add(cellSpawned);
                } else 
                {
                    Cell cellSpawned = Instantiate(wallTile);
                    cellSpawned.transform.position = new Vector2(i, j);
                    cells.Add(cellSpawned);
                }
                
            }
        }
    }

    public void GetNeighbours()
    {
        foreach(Cell currentCell in cells)
        {
            currentCell.doNeighbourCheck();
            //currentCell.checkHolder.SetActive(false);
        }
    }
}
