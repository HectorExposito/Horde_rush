using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public Sprite bigShield;
    public Sprite smallShield;
    float increment;
    void Start()
    {
        int num;
        num = Random.Range(0, 100);
        if (num<85)
        {
            GetComponent<SpriteRenderer>().sprite = smallShield;
            increment = 0.2f;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = bigShield;
            increment = 0.4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.player))
        {
            collision.GetComponent<PlayerManager>().increaseDefense(increment);
            Destroy(gameObject);
        }
    }
}
