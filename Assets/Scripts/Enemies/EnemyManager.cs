using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Enemy enemy;
    public Enemy.EnemyType enemyType;

    //private float actualAttackDelay;

    private void Start()
    {
        
        InitialValues();
    }

    private void InitialValues()
    {
        switch (enemyType)
        {
            case Enemy.EnemyType.Bat:
                enemy = new Bat(Enemy.EnemyType.Bat);
                break;
            case Enemy.EnemyType.Ghost:
                enemy = new Ghost(Enemy.EnemyType.Ghost);
                break;
            case Enemy.EnemyType.Rat:
                enemy = new Rat(Enemy.EnemyType.Rat);
                break;
            case Enemy.EnemyType.Spider:
                enemy = new Spider(Enemy.EnemyType.Spider);
                break;
            case Enemy.EnemyType.Warrior:
                enemy = new Warrior(Enemy.EnemyType.Warrior);
                break;
            case Enemy.EnemyType.Wizard:
                enemy = new Wizard(Enemy.EnemyType.Wizard);
                break;

        }
        this.GetComponent<SpriteRenderer>().sprite = enemy.sprite;
        this.GetComponent<EnemiesController>().speed = enemy.speed;
        //actualAttackDelay = 0;
    }

    public void TakeDamage(float defaultDamage)
    {
        GetComponent<Animator>().SetTrigger(AnimationParametersList.enemyDamageTaken);
        //Debug.Log(defaultDamage);
        enemy.health -= defaultDamage;
        //Debug.Log(enemy.health);
        if (enemy.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.transform.CompareTag(Tags.player))
        {
             collision.gameObject.GetComponent<PlayerManager>().TakeDamage(enemy.damage);
        }
        //actualAttackDelay = enemy.attackDelay;
    }

    public Enemy GetEnemy()
    {
        return enemy;
    }

    private void Update()
    {
        /*if (actualAttackDelay > 0)
        {
            actualAttackDelay -= Time.deltaTime;
        }*/
    }
}
