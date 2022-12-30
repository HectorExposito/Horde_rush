using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    
    public Ghost(EnemyType enemyType)
    {
        InitialValues(enemyType);
    }
    public override void InitialValues(EnemyType enemyType)
    {
        health = 100;
        speed = 2;
        damage = 1;
        attackDelay = 3;
        sprite = EnemiesList.instance.GetSprite(enemyType);
    }
}
