using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.spell)||collision.CompareTag(Tags.playerSpell))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.spear))
        {
            if (!collision.GetComponent<Spear>().isAlreadyAttached())
            {
                Destroy(collision.gameObject);
            }
            
        }
    }
}
