using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawner : MonoBehaviour
{
    public GameObject shuriken;
    private float delay;
    private float actualDelay;
    public int level;
    int numberOfShurikens;
    void Start()
    {
        level = 1;
        delay = 10;
        actualDelay = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (actualDelay <= 0)
        {
            for (int i = 0; i < numberOfShurikens; i++)
            {
                Instantiate(shuriken, transform);
                Instantiate(shuriken,new Vector3(transform.position.x*i,transform.position.y * i, transform.position.z*i),this.transform.rotation);
                
            }
            
            actualDelay = delay;
        }
        else
        {
            actualDelay -= Time.deltaTime;
        }
    }

    internal void levelUp()
    {
        level++;
        setValues();
    }

    private void setValues()
    {
        switch (level)
        {
            case 1:
                numberOfShurikens = 1;
                break;
            case 2:
                numberOfShurikens = 2;
                delay = 7;
                break;
            case 3:
                delay = 5;
                break;
            case 4:
                numberOfShurikens = 3;
                delay = 3;
                break;
            case 5:
                numberOfShurikens = 4;
                break;
        }
    }
}
