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
        health = 1;
        speed = 2;
        damage = 5;
        attackDelay = 1;
        sprite = EnemiesList.instance.GetSprite(enemyType);
    }
}
