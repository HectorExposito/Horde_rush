using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    
    public Bat(EnemyType enemyType)
    {
        InitialValues(enemyType);
    }
    public override void InitialValues(EnemyType enemyType)
    {
        health = 100;
        speed = 2;
        damage = 1;
        attackDelay = 2;
        sprite = EnemiesList.instance.GetSprite(enemyType);
    }
}
