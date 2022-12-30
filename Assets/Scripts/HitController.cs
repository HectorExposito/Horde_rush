using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform hitController;
    private float radio;
    private float damage;
    public WeaponManager weapon;

    private void Start()
    {
        timeBtwAttack = 0;
        radio = weapon.radio;
        damage = weapon.damage;
        startTimeBtwAttack = weapon.delay;
    }

    private void Update()
    {
        if (timeBtwAttack<=0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                weapon.GetComponent<Animator>().SetTrigger(AnimationParametersList.attack);
                Hit();
                timeBtwAttack = startTimeBtwAttack;
            }
            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            
        }
    }

    private void Hit()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(hitController.position,radio);

        foreach (Collider2D collider in objects)
        {
            if (collider.CompareTag("Enemy"))
            {
                float damageDealed = damage * FindObjectOfType<PlayerManager>().damageModifier;
                collider.transform.GetComponent<EnemyManager>().TakeDamage(damageDealed);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitController.position, radio);
    }

}
