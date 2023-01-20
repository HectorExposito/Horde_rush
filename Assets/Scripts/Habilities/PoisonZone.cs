using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonZone : MonoBehaviour
{
    int level;
    float radio;
    float lifeTime;
    float damage;
    float attackDelay;
    float actualAttackDelay;
    HashSet<Collider2D> enemiesInThePosionZone;
    
    void Start()
    {
        enemiesInThePosionZone = new HashSet<Collider2D>();
        this.transform.parent = null;
        this.transform.localScale = new Vector3(1, 1, 1);
        level = FindObjectOfType<PlayerManager>().GetComponent<PoisonPotionSpawner>().level;
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
            Destroy(gameObject);

        }
        else
        {
            lifeTime -= Time.deltaTime;
            actualAttackDelay -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.enemy))
        {
            collision.GetComponent<EnemyManager>().poisoned(lifeTime, attackDelay,damage);
        }
    }

    
}
