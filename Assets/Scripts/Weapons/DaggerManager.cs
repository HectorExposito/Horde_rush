using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerManager : MonoBehaviour
{
    private Dagger dagger;
    private float actualDelay;
    public int level;
    private void Start()
    {
        dagger = (Dagger)GetComponent<WeaponManager>().GetWeapon();
        actualDelay = dagger.attackDelay;
        level = 5;
    }
    void Update()
    {
        if (actualDelay<=0)
        {
            Attack();
            actualDelay = dagger.attackDelay;
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
            collision.GetComponent<EnemyManager>().TakeDamage(dagger.defaultDamage);
        }
    }

    private void Attack()
    {
        switch (level)
        {
            case 1:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.daggerAttack);
                break;
            case 2:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.daggerAttack2);
                break;
            case 3:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.daggerAttack2);
                break;
            case 4:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.daggerAttack3);
                break;
            case 5:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.daggerAttack4);
                break;
        }
    }
}
