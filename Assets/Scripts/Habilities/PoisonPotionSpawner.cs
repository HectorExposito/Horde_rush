using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPotionSpawner : MonoBehaviour
{
    public GameObject potion;
    private float delay;
    private float actualDelay;
    public int level;
    int numberOfPotions;
    void Start()
    {
        level = 1;
        setValues();
    }

    private void setValues()
    {
        Debug.Log("Spawner"+level);
        switch (level)
        {
            case 1:
                numberOfPotions = 1;
                delay = 5;
                break;
            case 2:
                numberOfPotions = 2;
                break;
            case 3:
                delay = 3;
                break;
            case 4:
                numberOfPotions = 3;
                break;
            case 5:
                delay = 1.75f;
                break;
        }
        actualDelay = delay;
    }

    void Update()
    {
        if (actualDelay <= 0)
        {
            for (int i = 0; i < numberOfPotions; i++)
            {
                Instantiate(potion, transform);
            }
            
            actualDelay = delay;
        }
        else
        {
            actualDelay -= Time.deltaTime;
        }
    }

    public void levelUp()
    {
        level++;
        setValues();
    }
}
