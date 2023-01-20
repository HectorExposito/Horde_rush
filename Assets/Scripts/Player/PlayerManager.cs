using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float damageModifier;
    public float defenseModifier;
    public float speedModifier;
    public GameObject weapon;
    //public Transform originalTransformWeapon;



    private void Start()
    {
        currentHealth = maxHealth;
        speedModifier = 1;
        damageModifier = 1;
        defenseModifier = 1;
        Instantiate(weapon);
        GameObject.FindGameObjectWithTag(Tags.weapon).transform.parent = transform;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    internal void ActivateHability(string tag)
    {
        switch (tag)
        {
            case Tags.wand:
                if (!GetComponent<Wand>().enabled)
                {
                    GetComponent<Wand>().enabled = true;
                }
                else
                {
                    GetComponent<Wand>().levelUp();
                }
                break;
            case Tags.shuriken:
                if (!GetComponent<ShurikenSpawner>().enabled)
                {
                    GetComponent<ShurikenSpawner>().enabled = true;
                }
                else
                {
                    GetComponent<ShurikenSpawner>().levelUp();
                }
                break;
            case Tags.poisonPotion:
                if (!GetComponent<PoisonPotionSpawner>().enabled)
                {
                    GetComponent<PoisonPotionSpawner>().enabled = true;
                }
                else
                {
                    GetComponent<PoisonPotionSpawner>().levelUp();
                }
                break;
            case Tags.icePotion:
                if (!GetComponent<IcePotionSpawner>().enabled)
                {
                    GetComponent<IcePotionSpawner>().enabled = true;
                }
                else
                {
                    GetComponent<IcePotionSpawner>().levelUp();
                }
                break;
            case Tags.spear:
                if (!GetComponent<SpearSpawner>().enabled)
                {
                    GetComponent<SpearSpawner>().enabled = true;
                }
                else
                {
                    GetComponent<SpearSpawner>().levelUp();
                }
                break;
            case Tags.twistedWand:
                if (!GetComponent<BeamSpawner>().enabled)
                {
                    GetComponent<BeamSpawner>().enabled = true;
                }
                else
                {
                    GetComponent<BeamSpawner>().levelUp();
                }
                break;
        }
    }

    internal void levelUp()
    {
        
    }

    public void TakeDamage(float damage)
    {
        GetComponent<Animator>().SetTrigger(AnimationParametersList.playerDamageTaken);
        currentHealth -= damage/ damageModifier;
        if (currentHealth <= 0)
        {
            gameObject.active = false;
        }
    }

    public void RecoverHealth(float health)
    {
        if (currentHealth + health > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += health;
        }
    }

    public void increaseDefense(float increment)
    {
        defenseModifier += increment;
        
    }

    public void increaseDamage(float increment)
    {
        damageModifier += increment;
    }

    public void increaseSpeed(float increment)
    {
        speedModifier += increment;
    }
}
