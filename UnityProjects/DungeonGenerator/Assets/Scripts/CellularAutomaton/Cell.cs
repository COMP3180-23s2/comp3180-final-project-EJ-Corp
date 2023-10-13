using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] public GameObject[] neighbours = new GameObject[8];
    [SerializeField] private GameObject checkers;
    // Start is called before the first frame update
    void Start()
    {
        checkers = transform.Find("NeighbourCheckers").gameObject;
        checkers.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
