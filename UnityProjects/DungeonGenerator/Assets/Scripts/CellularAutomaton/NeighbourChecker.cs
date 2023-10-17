using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourChecker : MonoBehaviour
{
    [SerializeField] private int position;
    [SerializeField] private LayerMask cellLayer;
    [SerializeField] private Cell parentCell;
    // Start is called before the first frame update
    void Awake()
    {
        parentCell = transform.parent.parent.GetComponent<Cell>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject collided = other.gameObject;

        //Debug.Log(position + "collided");
        if(cellLayer.Contains(collided))
        {
            parentCell.neighbours[position] = collided;
            Destroy(gameObject);
        }
    }
}
