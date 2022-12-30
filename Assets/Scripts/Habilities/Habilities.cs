using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilities : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.player))
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
