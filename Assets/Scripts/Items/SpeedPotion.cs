using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    float increase;
    void Start()
    {
        increase = 0.20f; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.player))
        {
            FindObjectOfType<PlayerManager>().increaseSpeed(increase);
            Destroy(gameObject);
        }
    }

}
