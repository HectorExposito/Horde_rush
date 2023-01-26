using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float damageModifier;
    public float defenseModifier;
    public float speedModifier;
    public TMP_Text modifierText;

    public GameObject weapon;
    public LevelManager levelManager;

    public GameObject habilitySelectionPanel;
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
        habilitySelectionPanel.SetActive(true);
        habilitySelectionPanel.GetComponent<HabilitiesSelection>().chooseHabilities();
        levelManager.pauseGame();
        
    }

    public void TakeDamage(float damage)
    {
        GetComponent<Animator>().SetTrigger(AnimationParametersList.playerDamageTaken);
        currentHealth -= damage/ damageModifier;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            levelManager.pauseGame();
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
        if ((defenseModifier + increment) <= 2)
        {
            defenseModifier += increment;
        }
        else
        {
            defenseModifier = 2;
        }
        
        if (increment<0.2)
        {
            modifierText.text = "Defense +";
        }
        else
        {
            modifierText.text = "Defense ++";
        }
        StartCoroutine(statModifierCoroutine());
    }

    public void increaseDamage(float increment)
    {
        if ((damageModifier + increment) <= 2)
        {
            damageModifier += increment;
        }
        else
        {
            damageModifier = 2;
        }
        if (increment < 0.2)
        {
            modifierText.text = "Attack +";
        }
        else
        {
            modifierText.text = "Attack ++";
        }
        StartCoroutine(statModifierCoroutine());
    }

    public void increaseSpeed(float increment)
    {
        if ((speedModifier + increment) <= 2)
        {
            speedModifier += increment;
        }
        else
        {
            speedModifier = 2;
        }
        modifierText.text = "Speed +";
        StartCoroutine(statModifierCoroutine());
    }

    private IEnumerator statModifierCoroutine()
    {
        modifierText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        modifierText.gameObject.SetActive(false);
    }
}
