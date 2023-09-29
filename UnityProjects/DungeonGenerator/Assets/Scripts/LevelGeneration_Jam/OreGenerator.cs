using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreGenerator : MonoBehaviour
{
    private enum oreType
    {
        gold, magnetite
    };

    [SerializeField] private oreType chosenType;

    [SerializeField] private List<GameObject> goldPrefabs;
    [SerializeField] private List<GameObject> magPrefabs;
    [SerializeField] private GameObject chosenOre;
    [SerializeField] private int dropChance;
    [SerializeField] private int dropRoll;
    [SerializeField] private GameObject tracker;
    // Start is called before the first frame update
    void Start()
    {
        ChooseOre();
        RollForOre();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseOre()
    {
        int oreRoll;
        switch(chosenType)
        {
            
            case oreType.gold:
                oreRoll = Random.Range(0, goldPrefabs.Count);
                chosenOre = goldPrefabs[oreRoll];
                break;

            case oreType.magnetite:
                oreRoll = Random.Range(0, magPrefabs.Count);
                chosenOre = magPrefabs[oreRoll];
                break;
        }
        
    }

    public void RollForOre()
    {
        dropRoll = Random.Range(1, 11);

        if(dropRoll <= dropChance)
        {
            GameObject ore = Instantiate(chosenOre);
            ore.transform.position = transform.position;
            ore.transform.parent = transform.parent;
        }
        Destroy(gameObject);
    }
}
