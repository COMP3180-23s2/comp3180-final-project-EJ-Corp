using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] public Cell[] neighbours = new Cell[8];
    [SerializeField] public GameObject checkHolder;
    [SerializeField] private Collider2D[] checkers = new Collider2D[8];
    [SerializeField] private int neighbourWallCount = 0;

    private SpriteRenderer sprite;
    [SerializeField] private Color wallColor;
    [SerializeField] private Color floorColor;

    public enum CellState
    {
        wall, floor
    }
    
    public CellState cellState;

    public CellState nextState;
    // Start is called before the first frame update
    void Awake()
    {
        checkHolder = transform.Find("NeighbourCheckers").gameObject;
        sprite = transform.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        ChangeState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState()
    {
        switch(cellState)
        {
            case CellState.wall:
                sprite.color = wallColor;
                break;

            case CellState.floor:
                sprite.color = floorColor;
                break;
        }
    }

    public void DoNeighbourCheck()
    {
        for(int i = 0; i < checkers.Length; i++)
        {
            checkers[i].isTrigger = true;
        }
    }

    public void CheckNextState()
    {
        neighbourWallCount = 0;
        for(int i = 0; i < neighbours.Length; i++)
        {
            if(neighbours[i] == null)
            {
                neighbourWallCount++;
                continue;
            } else if(neighbours[i].cellState == CellState.wall)
            {
                neighbourWallCount++;
            }
        }

        if(neighbourWallCount > 4)
        {
            nextState = CellState.wall;
        } else
        {
            nextState = CellState.floor;
        }
    }
}
