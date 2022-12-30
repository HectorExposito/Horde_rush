using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeManager : MonoBehaviour
{
    private Axe axe;
    private float actualDelay;
    public int level;
    private void Start()
    {
        axe = (Axe)GetComponent<WeaponManager>().GetWeapon();
        actualDelay = axe.attackDelay;
        level = 1;
    }
    void Update()
    {
        if (actualDelay <= 0)
        {
            Attack();
            actualDelay = axe.attackDelay;
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
            collision.GetComponent<EnemyManager>().TakeDamage(axe.defaultDamage);
        }
    }
    private void Attack()
    {
        switch (level)
        {
            case 1:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.axeAttack);
                break;
            case 2:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.axeAttack2);
                break;
            case 3:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.axeAttack2);
                break;
            case 4:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.axeAttack3);
                break;
            case 5:
                GetComponent<Animator>().SetTrigger(AnimationParametersList.axeAttack3);
                break;
        }
    }
}
