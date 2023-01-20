using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpawner : MonoBehaviour
{
    int damage;
    float attackDelay;
    float actualAttackDelay;
    float speed;
    public GameObject spear;
    public int level;
    int numberOfSpears;
    void Start()
    {
        level = 1;
        numberOfSpears = 1;
        damage = 5;
        attackDelay = 7f;
        speed = 5f;
        actualAttackDelay = attackDelay;
    }

    public float GetSpeed()
    {
        return speed;
    }
    public float GetDamage()
    {
        return damage;
    }


    void Update()
    {
        if (actualAttackDelay > 0)
        {
            actualAttackDelay -= Time.deltaTime;
        }
        else
        {
            for (int i = 0; i < numberOfSpears; i++)
            {
                Attack();
            }
            actualAttackDelay = attackDelay;
        }
    }

    private void Attack()
    {
        Instantiate(spear, transform.position, transform.rotation);
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
                numberOfSpears = 1;
                break;
            case 2:
                numberOfSpears = 2;
                break;
            case 3:
                damage = 10;
                attackDelay = 5;
                break;
            case 4:
                damage = 15;
                numberOfSpears = 3;
                break;
            case 5:
                attackDelay = 2;
                break;
            default:
                break;
        }
    }
}
