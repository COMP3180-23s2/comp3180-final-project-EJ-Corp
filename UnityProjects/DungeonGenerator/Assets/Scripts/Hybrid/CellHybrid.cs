using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHybrid : MonoBehaviour
{
    [SerializeField] private Vector2 gridPosition;
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
}
