using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] possibleItems;
    private GameObject item;
    int num;
    void Start()
    {
        num = Random.Range(0, possibleItems.Length - 1);
        item = possibleItems[num];
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
