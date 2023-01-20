using System;
using UnityEngine;

public class WizardManager : MonoBehaviour
{
    public GameObject spell;
    public float distance;
    public float actualAttackDelay;

    private void Start()
    {
        actualAttackDelay = 0;
    }

    void Update()
    {
        if (actualAttackDelay > 0)
        {
            actualAttackDelay -= Time.deltaTime;
        }
        else
        {
            if (FindObjectOfType<PlayerManager>() != null)
            {
                Attack();
                actualAttackDelay = GetComponent<EnemyManager>().GetEnemy().attackDelay;
            }
             
        }
    }

    private void Attack()
    {
        Instantiate(spell,transform.position,transform.rotation);
    }
}
