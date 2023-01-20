using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    private Sword sword;
    private float actualDelay;
    public int level;
    private void Start()
    {
        sword = (Sword)GetComponent<WeaponManager>().GetWeapon();
        actualDelay = sword.attackDelay;
        level = 5;
    }
    void Update()
    {
        if (actualDelay <= 0)
        {
            Attack();
            actualDelay = sword.attackDelay;
        }
        else
        {
            actualDelay -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.enemy))
        {
            if (collision.GetComponent<GhostManager>() == null || !collision.GetComponent<GhostManager>().ghostCollider.isTrigger)
            {
                collision.GetComponent<EnemyManager>().TakeDamage(sword.defaultDamage);
            }
            
        }
    }

    private void Attack()
    {
        switch (level)
        {
            case 1:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.swordAttack);
                break;
            case 2:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.swordAttack2);
                break;
            case 3:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.swordAttack2);
                break;
            case 4:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.swordAttack3);
                break;
            case 5:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.swordAttack4);
                break;
        }
    }
}
