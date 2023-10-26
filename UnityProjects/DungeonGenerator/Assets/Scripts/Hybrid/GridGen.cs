using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridGen : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoints;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private int spreadOffset;

    
    void Start()
    {
        
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
                Vector3 currentPos = new Vector3(i * spreadOffset, 0, j * spreadOffset);
                GameObject spawnPoint = Instantiate(spawnPoints);
                spawnPoint.transform.position = currentPos;
            }
        }
    }
}
