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
}
