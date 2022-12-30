using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public float speed;
    public float damage;
    private Vector3 targetPosition;
    public float rotationSpeed;

    void Start()
    {
        speed = 5f;
        targetPosition = FindObjectOfType<PlayerManager>().gameObject.transform.position;
        gameObject.GetComponent<Rigidbody2D>().velocity = (targetPosition - transform.position).normalized*speed;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0,0,-rotationSpeed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.player))
        {
             collision.GetComponent<PlayerManager>().TakeDamage(damage);
             Destroy(gameObject);
        }
        
    }
}
