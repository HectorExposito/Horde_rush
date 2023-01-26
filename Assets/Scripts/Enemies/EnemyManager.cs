using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Enemy enemy;
    public Enemy.EnemyType enemyType;
    bool killed;
    float poisonZoneLifeTime;
    float poisonDamageDelay;
    float poisonDamage;
    private float actualAttackDelay;
    public ExperienceOrb experienceOrb;

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
        actualAttackDelay = 0;
    }

    public void TakeDamage(float defaultDamage)
    {
        if (this.GetComponent<GhostManager>() == null || !this.GetComponent<GhostManager>().ghostCollider.isTrigger)
        {
            GetComponent<Animator>().SetTrigger(AnimationParametersList.enemyDamageTaken);
            enemy.health -= defaultDamage;
            if (enemy.health <= 0)
            {
                if (!killed)
                {
                    killed = true;
                    FindObjectOfType<LevelManager>().enemyKilled();
                    
                }
                Instantiate(experienceOrb, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.transform.CompareTag(Tags.player)&&actualAttackDelay<=0)
        {
             collision.gameObject.GetComponent<PlayerManager>().TakeDamage(enemy.damage);
             actualAttackDelay = enemy.attackDelay;
        }
        actualAttackDelay -= Time.deltaTime;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.transform.CompareTag(Tags.player))
        {
            actualAttackDelay = 0;
        }
    }
    public Enemy GetEnemy()
    {
        return enemy;
    }

    public void poisoned(float poisonZoneLifeTime,float poisonDamageDelay, float damage)
    {
        this.poisonZoneLifeTime = poisonZoneLifeTime;
        this.poisonDamageDelay = poisonDamageDelay;
        poisonDamage = damage;
        gameObject.GetComponent<SpriteRenderer>().material.color = Color.green;
        takePoisonDamage();
    }

    private void takePoisonDamage()
    {
        if (poisonZoneLifeTime > 0)
        {
            StartCoroutine(PoisonDamageCoroutine());
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
        }
    }


    private IEnumerator PoisonDamageCoroutine()
    {
        yield return new WaitForSeconds(poisonDamageDelay);
        this.TakeDamage(poisonDamage);
        poisonZoneLifeTime -= poisonDamageDelay;
        Debug.Log(poisonZoneLifeTime);
        takePoisonDamage();
        
    }
}
