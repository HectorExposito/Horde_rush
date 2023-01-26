using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] possibleItems;//0-> Health 1->Speed 2->Shield 3-> Sword
    private GameObject item;
    public GameObject[] possibleExperienceOrbs;
    int num;
    PlayerManager pm;
    bool alreadySpawned;
    void Start()
    {
        pm = FindObjectOfType<PlayerManager>();
        alreadySpawned = false;
    }

    public void spawnItem()
    {
        if (!alreadySpawned)
        {
            alreadySpawned = true;
            num = Random.Range(0, possibleItems.Length);
            item = possibleItems[num];
            if (canSpawnItem())
            {
                Instantiate(item, transform.position, transform.rotation);
            }
            else
            {
                num = Random.Range(0, possibleExperienceOrbs.Length);
                Instantiate(possibleExperienceOrbs[num], transform.position, transform.rotation);
            }
            StartCoroutine(destroyChestCoroutine());
        }
        
    }

    private bool canSpawnItem()
    {
        switch (num)
        {
            case 0:
                return true;
            case 1:
                if (pm.speedModifier < 2)
                {
                    return true;
                }
                break;
            case 2:
                if (pm.defenseModifier < 2)
                {
                    return true;
                }
                break;
            case 3:
                if (pm.damageModifier < 2)
                {
                    return true;
                }
                break;
        }
        return false;
    }

    private IEnumerator destroyChestCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<ChestSpawner>().reduceNumOfChests();
        Destroy(gameObject);
    }
}
