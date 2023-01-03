using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceZone : MonoBehaviour
{
    int level;
    float radio;
    float lifeTime;
    int damage;
    float attackDelay;
    float actualAttackDelay;
    LinkedList<Collider2D> enemiesInTheIceZone;
    void Start()
    {
        this.transform.parent = null;
        this.transform.localScale = new Vector3(1, 1, 1);
        enemiesInTheIceZone = new LinkedList<Collider2D>();
        //level = FindObjectOfType<PlayerManager>().GetComponent<PoisonPotionSpawner>().level;
        level = 1;
        setValues();
    }

    private void setValues()
    {
        switch (level)
        {
            case 1:
                radio = 1;
                lifeTime = 4;
                damage = 5;
                attackDelay = 1.5f;
                break;
            case 2:
                radio = 1.15f;
                lifeTime = 4;
                damage = 10;
                attackDelay = 1.5f;
                break;
            case 3:
                radio = 1.25f;
                lifeTime = 6;
                damage = 10;
                attackDelay = 1f;
                break;
            case 4:
                radio = 1.5f;
                lifeTime = 6;
                damage = 15;
                attackDelay = 1f;
                break;
            case 5:
                radio = 1.5f;
                lifeTime = 9;
                damage = 20;
                attackDelay = 0.5f;
                break;
        }
        actualAttackDelay = attackDelay;
        this.transform.localScale = this.transform.localScale * radio;
    }

    void Update()
    {
        if (lifeTime <= 0)
        {
            restoreEnemiesSpeed();
            Destroy(gameObject);

        }
        else
        {
            lifeTime -= Time.deltaTime;
        }
    }

    private void restoreEnemiesSpeed()
    {
        foreach (Collider2D enemy in enemiesInTheIceZone)
        {
            enemy.GetComponent<EnemiesController>().setDefaultSpeed();
            enemy.GetComponent<SpriteRenderer>().material.color = Color.white;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.enemy))
        {
            collision.GetComponent<SpriteRenderer>().material.color=Color.blue;
            collision.GetComponent<EnemiesController>().slowDown();
            enemiesInTheIceZone.AddLast(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.enemy))
        {
            collision.GetComponent<EnemiesController>().setDefaultSpeed();
            collision.GetComponent<SpriteRenderer>().material.color = Color.white;
        }
    }
}
