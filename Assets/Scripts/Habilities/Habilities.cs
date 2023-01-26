using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilities : MonoBehaviour
{
    float timeToPickUp;
    private void Start()
    {
        timeToPickUp = 0.5f;
    }
    private void Update()
    {
        if (timeToPickUp > 0)
        {
            timeToPickUp -= Time.deltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag(Tags.player)&&timeToPickUp<=0)
        {
            GiveHability();
            Destroy(gameObject);
        }
    }

    private void GiveHability()
    {
        FindObjectOfType<PlayerManager>().ActivateHability(gameObject.tag);
    }

    public string GetName()
    {
        return this.tag;
    }

    public string GetDescription(int num)
    {
        switch (num)
        {
            case 0:
                return wandDescription();
            case 1:
                return shurikenDescription();
            case 2:
                return poisonPotionDescription();
            case 3:
                return icePotionDescription();
            case 4:
                return spearDescription();
            case 5:
                return beamDescription();
        }
        return "";
    }

    private string beamDescription()
    {
        int level = FindObjectOfType<PlayerManager>().GetComponent<BeamSpawner>().level;
        switch (level)
        {
            case 0:
                return "1 beam fired to one direction";
            case 1:
                return "+ 1 Beam\n+ Speed";
            case 2:
                return "+ Damage\n- Delay";
            case 3:
                return "+ 1 Beam\n+ Speed\n- Delay";
            case 4:
                return "+ 1 Beam\n+ Speed\n+ Damage";
        }
        return "";
    }

    private string spearDescription()
    {
        int level = FindObjectOfType<PlayerManager>().GetComponent<SpearSpawner>().level;
        switch (level)
        {
            case 0:
                return "1 spear thrown to a random direction. It causes bleeding.";
            case 1:
                return "+ 1 Spear";
            case 2:
                return "+ Damage\n- Delay";
            case 3:
                return "+ 1 Spear\n+ Damage";
            case 4:
                return "- Delay";
        }
        return "";
    }

    private string icePotionDescription()
    {
        int level = FindObjectOfType<PlayerManager>().GetComponent<IcePotionSpawner>().level;
        switch (level)
        {
            case 0:
                return "1 ice potion thrown to a random direction. Freezes all enemies that touch it.";
            case 1:
                return "+ 1 Potion\n+ Area";
            case 2:
                return "- Delay\n+ Area\n+ Time";
            case 3:
                return "+ 1 Potion\n+ Area";
            case 4:
                return "- Delay\n+ Time";
        }
        return "";
    }

    private string poisonPotionDescription()
    {
        int level = FindObjectOfType<PlayerManager>().GetComponent<PoisonPotionSpawner>().level;
        switch (level)
        {
            case 0:
                return "1 poison potion thrown to a random direction. Poisons all enemies that touch it.";
            case 1:
                return "+ 1 Potion\n+ Area\n+ Damage";
            case 2:
                return "- Delay\n+ Area\n+ Time\n- Delay";
            case 3:
                return "+ 1 Potion\n+ Area\n+ Damage";
            case 4:
                return "- Delay\n+ Time\n+ Damage\n- Delay";
        }
        return "";
    }

    private string shurikenDescription()
    {
        int level = FindObjectOfType<PlayerManager>().GetComponent<ShurikenSpawner>().level;
        switch (level)
        {
            case 0:
                return "1 shuriken orbits you. It destroys spells.";
            case 1:
                return "+ 1 Shuriken";
            case 2:
                return "- Delay";
            case 3:
                return "+ 1 Shuriken\n- Delay";
            case 4:
                return "+ 1 Shuriken";
        }
        return "";
    }

    private string wandDescription()
    {
        int level = FindObjectOfType<PlayerManager>().GetComponent<Wand>().level;
        switch (level)
        {
            case 0:
                return "1 spell thrown to a random direction.";
            case 1:
                return "+ 1 Spell";
            case 2:
                return "- Delay\n+ Damage";
            case 3:
                return "+ 1 Spell\n+ Damage";
            case 4:
                return "+ 1 Spell\n- Delay";
        }
        return "";
    }
}
