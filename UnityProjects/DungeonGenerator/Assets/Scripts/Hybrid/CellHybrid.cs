using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHybrid : MonoBehaviour
{
    [SerializeField] public Vector2 gridPosition;
    public bool taken = false;
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
}
