using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePotionSpawner : MonoBehaviour
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
        
        switch (level)
        {
            case 1:
                numberOfPotions = 1;
                delay = 15f;
                break;
            case 2:
                numberOfPotions = 2;
                break;
            case 3:
                delay = 12.5f;
                break;
            case 4:
                numberOfPotions = 3;
                break;
            case 5:
                delay = 10f;
                break;
            default:
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
