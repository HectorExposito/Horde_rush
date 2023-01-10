using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class BeamSpawner : MonoBehaviour
{
    Semaphore directionSemaphore;
    public GameObject beam;
    int numberOfBeams;
    public int level;
    int direction;
    float attackDelay;
    float actualAttackDelay;
    float speed;
    int damage;
    static bool directionGiven;
    void Start()
    {
        directionSemaphore = new Semaphore(0,1);
        level = 1;
        setValues();
    }

    internal float GetDamage()
    {
        return damage;
    }

    internal float GetSpeed()
    {
        return speed;
    }

    void Update()
    {
        if (actualAttackDelay > 0)
        {
            actualAttackDelay -= Time.deltaTime;
        }
        else
        {
            for (int i = 0; i < numberOfBeams; i++)
            {
                Attack();
            }
            actualAttackDelay = attackDelay;
        }
    }

    private void Attack()
    {
        Instantiate(beam, transform);
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
                numberOfBeams = 1;
                damage = 20;
                speed = 3;
                attackDelay = 10;
                break;
            case 2:
                numberOfBeams = 2;
                speed = 4;
                break;
            case 3:
                damage = 30;
                attackDelay = 7;
                break;
            case 4:
                numberOfBeams = 3;
                speed = 5;
                attackDelay = 5;
                break;
            case 5:
                numberOfBeams = 4;
                damage = 40;
                speed = 5;
                attackDelay = 5;
                break;
        }
    }

    public int getDirection()
    {
        //directionSemaphore.WaitOne();
        int directionReturned = direction;
        if (direction < 4)
        {
            direction++;
        }
        else
        {
            direction = 1;
        }
        return directionReturned;
    }
}
