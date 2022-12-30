using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPotion : MonoBehaviour
{
    public GameObject poisonZone;
    public float speed;
    private Vector3 targetPosition;
    public float rotationSpeed;
    public float timeToBreak;
    void Start()
    {

        speed = 1;
        targetPosition = new Vector3(Random.Range(-1,1), Random.Range(-1, 1), 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = (targetPosition - transform.position).normalized * speed;
    }

    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -rotationSpeed));
        
        if (timeToBreak<=0)
        {
            Instantiate(poisonZone, transform);
            Destroy(gameObject);
        }
        else
        {
            timeToBreak -= Time.deltaTime;
        }
    }
}
