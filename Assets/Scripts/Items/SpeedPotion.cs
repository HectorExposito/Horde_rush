using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    float increase;
    float timeToPickUp;
    void Start()
    {
        timeToPickUp = 0.5f;
        increase = 0.10f; 
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
            FindObjectOfType<PlayerManager>().increaseSpeed(increase);
            Destroy(gameObject);
        }
    }

}
