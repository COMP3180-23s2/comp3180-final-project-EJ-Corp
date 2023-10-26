using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    [SerializeField] private List<int> doors;
        //Door 1 = Top
        //Door 2 = Right
        //Door 3 = Bottom
        //Door 4 = Left

    [SerializeField] private CellHybrid roomCell;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChoosePath()
    {
        int pathChosen = Random.Range(0, doors.Count);
        
    }

    public void SetRoomCell(CellHybrid cell)
    {
        roomCell = cell;
    }
}
