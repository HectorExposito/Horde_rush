
using System;
using UnityEngine;

public abstract class Enemy 
{
    public float health;
    public float speed;
    public float damage;
    public Sprite sprite;
    public EnemyType enemyType;
    public float attackDelay;

    public abstract void InitialValues(EnemyType enemyType);
    
    public enum EnemyType
    {
        Wizard, 
        Spider, 
        Bat, 
        Warrior, 
        Ghost, 
        Rat
    }
    
    
}
