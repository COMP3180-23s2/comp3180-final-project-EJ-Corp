using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellularGrid : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private int density;

    [SerializeField] private GameObject floorTile;
    [SerializeField] private GameObject wallTile;

    [SerializeField] private Cell[,] cells;

    [SerializeField] private Transform spawnPos;
    [SerializeField] private Vector2 spawnShift;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    GameObject cellSpawned = Instantiate(floorTile);
                    cellSpawned.transform.position = new Vector2(i, j);
                } else 
                {
                    GameObject cellSpawned = Instantiate(wallTile);
                    cellSpawned.transform.position = new Vector2(i, j);
                }
                
            }
        }
    }
}
