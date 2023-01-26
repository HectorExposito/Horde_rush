using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public Sprite bigShield;
    public Sprite smallShield;
    float increment;
    float timeToPickUp;
    void Start()
    {
        timeToPickUp = 0.5f;
        int num;
        num = Random.Range(0, 100);
        if (num<85)
        {
            GetComponent<SpriteRenderer>().sprite = smallShield;
            increment = 0.1f;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = bigShield;
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
            collision.GetComponent<PlayerManager>().increaseDefense(increment);
            Destroy(gameObject);
        }
    }
}
