using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIncrementManager : MonoBehaviour
{
    public Sprite bigSword;
    public Sprite smallSword;
    float increment;
    float timeToPickUp;
    void Start()
    {
        timeToPickUp = 0.5f;
        int num;
        num = Random.Range(0, 100);
        if (num < 85)
        {
            GetComponent<SpriteRenderer>().sprite = smallSword;
            increment = 0.1f;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = bigSword;
            increment = 0.2f;
        }
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
        if (collision.CompareTag(Tags.player) && timeToPickUp <= 0)
        {
            collision.GetComponent<PlayerManager>().increaseDamage(increment);
            Destroy(gameObject);
        }
    }

}
