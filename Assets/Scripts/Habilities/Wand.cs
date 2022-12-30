using UnityEngine;

public class Wand : MonoBehaviour
{
    int damage;
    float attackDellay;
    float actualAttackDelay;
    float speed;
    public GameObject spell;
    public int level;
    int numberOfSpells;
    void Start()
    {
        level = 1;
        numberOfSpells = 1;
        damage = 10;
        attackDellay = 7f;
        speed = 5f;
        actualAttackDelay = attackDellay;
    }

    public float GetSpeed()
    {
        return speed;
    }
    public float GetDamage()
    {
        return damage;
    }

    
    void Update()
    {
        if (actualAttackDelay > 0)
        {
            actualAttackDelay -= Time.deltaTime;
        }
        else
        {
            for (int i = 0; i < numberOfSpells; i++)
            {
                Attack();
            }
            actualAttackDelay = attackDellay;
        }
    }

    private void Attack()
    {
        Instantiate(spell,transform.position,transform.rotation);
    }

    internal void levelUp()
    {
        level++;
        setValues();
    }

    private void setValues()
    {
        switch (level)
        {
            case 1:
                numberOfSpells = 1;
                break;
            case 2:
                numberOfSpells = 2;
                break;
            case 3:
                damage = 15;
                attackDellay = 5;
                break;
            case 4:
                damage = 20;
                numberOfSpells = 3;
                break;
            case 5:
                numberOfSpells = 4;
                attackDellay = 2;
                break;
        }
    }
}
