using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Enemy
{
    public Warrior(EnemyType enemyType)
    {
        InitialValues(enemyType);
    }
    public override void InitialValues(EnemyType enemyType)
    {
        health = 30;
        speed = 1.5f;
        damage = 20;
        attackDelay = 3;
        sprite = EnemiesList.instance.GetSprite(enemyType);
    }
}
