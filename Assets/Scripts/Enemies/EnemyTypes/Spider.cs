using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    public Spider(EnemyType enemyType)
    {
        InitialValues(enemyType);
    }
    public override void InitialValues(EnemyType enemyType)
    {
        health = 10;
        speed = 2.2f;
        damage = 10;
        attackDelay = 2;
        sprite = EnemiesList.instance.GetSprite(enemyType);
    }
}
