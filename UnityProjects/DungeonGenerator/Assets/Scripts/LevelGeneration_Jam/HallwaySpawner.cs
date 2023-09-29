using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwaySpawner : MonoBehaviour
{

    [SerializeField] private int doorLocation;
    //1 = top
    //2 = right
    //3 = bottom
    //4 = left

    [SerializeField] private HallwayTemplates templates;
    [SerializeField] private int hallRoll;

    [SerializeField] private bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Templates").GetComponent<HallwayTemplates>();
        Invoke("SpawnRoom", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRoom()
    {
        GameObject spawnedRoom;

        if(!spawned)
        {
            switch(doorLocation)
            {
                case 1:
                    hallRoll = Random.Range(0, templates.topHalls.Length);
                    spawnedRoom = Instantiate(templates.topHalls[hallRoll]);
                    spawnedRoom.transform.position = transform.position;
                    break;

                case 2:
                    hallRoll = Random.Range(0, templates.rightHalls.Length);
                    spawnedRoom = Instantiate(templates.rightHalls[hallRoll]);
                    spawnedRoom.transform.position = transform.position;
                    break;

                case 3:
                    hallRoll = Random.Range(0, templates.bottomHalls.Length);
                    spawnedRoom = Instantiate(templates.bottomHalls[hallRoll]);
                    spawnedRoom.transform.position = transform.position;
                    break;

                case 4:
                    hallRoll = Random.Range(0, templates.leftHalls.Length);
                    spawnedRoom = Instantiate(templates.leftHalls[hallRoll]);
                    spawnedRoom.transform.position = transform.position;
                    break;
            }

            spawned = true;
        }
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }
}
