using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] public Cell[] neighbours = new Cell[8];
    [SerializeField] public GameObject checkHolder;
    [SerializeField] private bool isWall;
    [SerializeField] private Collider2D[] checkers = new Collider2D[8];
    [SerializeField] private int neighbourWallCount = 0;
    // Start is called before the first frame update
    void Awake()
    {
        checkHolder = transform.Find("NeighbourCheckers").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        for(int i = 0; i < neighbours.Length; i++)
        {
            if(neighbours[i] == null)
            {
                continue;
            } else if(neighbours[i].isWall)
            {
                neighbourWallCount++;
            }
        }
    }
}
