using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIncrementManager : MonoBehaviour
{
    public Sprite bigSword;
    public Sprite smallSword;
    float increment;
    void Start()
    {
        int num;
        num = Random.Range(0, 100);
        if (num < 85)
        {
            GetComponent<SpriteRenderer>().sprite = smallSword;
            increment = 0.2f;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = bigSword;
            increment = 0.4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.player))
        {
            collision.GetComponent<PlayerManager>().increaseDamage(increment);
            Destroy(gameObject);
        }
    }

}
