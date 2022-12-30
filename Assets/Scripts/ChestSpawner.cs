using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    const int MAX_CHEST =4;
    public int numberOfChests=0;
    public GameObject chest;
    private LevelManager levelManager;
    
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    internal void reduceNumOfChests()
    {
        numberOfChests--;
    }

    // Update is called once per frame
    void Update()
    {
        if (MAX_CHEST > numberOfChests)
        {
            spawnChest();
        }
    }

    private void spawnChest()
    {
        float x = UnityEngine.Random.Range(levelManager.GetMinX(),levelManager.GetMaxX());
        float y = UnityEngine.Random.Range(levelManager.GetMinY(), levelManager.GetMaxY());
        Instantiate(chest,new Vector3(x,y,0),Quaternion.Euler(0,0,0));
        numberOfChests++;
    }
}
