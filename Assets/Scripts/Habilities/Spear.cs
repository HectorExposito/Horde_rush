using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    float speed;
    float damage;
    float bleedingTime;
    float attachDelay;
    float actualBleedingTime;
    private Vector3 targetPosition;
    bool alreadyAttached;
    PlayerManager player;
    void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        attachDelay =0.25f;
        damage = FindObjectOfType<SpearSpawner>().GetDamage();
        speed = FindObjectOfType<SpearSpawner>().GetSpeed();
        bleedingTime = 1;

        targetPosition = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0);
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        gameObject.GetComponent<Rigidbody2D>().velocity = moveDirection * speed;
        
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg-82;
        Quaternion newRotation = Quaternion.AngleAxis((angle), Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.enemy))
        {
            if (!alreadyAttached && attachDelay<=0)
            {
                this.transform.parent = collision.transform;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0) ;
                transform.parent.gameObject.GetComponent<EnemyManager>().TakeDamage(damage*player.damageModifier);
                alreadyAttached = true;
            }
        }
    }
    private void Update()
    {
        if (alreadyAttached)
        {
            if (actualBleedingTime <= 0)
            {
                transform.parent.gameObject.GetComponent<EnemyManager>().TakeDamage(damage/5);
                actualBleedingTime = bleedingTime;
            }
            else
            {
                actualBleedingTime -= Time.deltaTime;
            }
        }
        else
        {
            attachDelay-=Time.deltaTime;
        }
    }

    public bool isAlreadyAttached()
    {
        return alreadyAttached;
    }
}
