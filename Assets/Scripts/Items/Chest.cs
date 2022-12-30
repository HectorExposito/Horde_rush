using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] possibleItems;
    private GameObject item;
    void Start()
    {
        item = possibleItems[Random.Range(0,possibleItems.Length)];
    }

    public void spawnItem()
    {
        Instantiate(item, transform.position, transform.rotation);
        StartCoroutine(destroyChestCoroutine());
    }

    private IEnumerator destroyChestCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<ChestSpawner>().reduceNumOfChests();
        Destroy(gameObject);
    }
}
