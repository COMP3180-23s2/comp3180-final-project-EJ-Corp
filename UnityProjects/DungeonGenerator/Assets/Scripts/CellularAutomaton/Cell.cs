using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] public GameObject[] neighbours = new GameObject[8];
    [SerializeField] public GameObject checkHolder;
    [SerializeField] private Collider2D[] checkers = new Collider2D[8];
    // Start is called before the first frame update
    void Awake()
    {
        checkHolder = transform.Find("NeighbourCheckers").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doNeighbourCheck()
    {
        for(int i = 0; i < checkers.Length; i++)
        {
            checkers[i].isTrigger = true;
        }
    }
}
