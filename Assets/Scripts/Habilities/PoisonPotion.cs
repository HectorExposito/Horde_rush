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
    public bool instantiated;
    void Start()
    {
        transform.parent = null;
        targetPosition = new Vector3(Random.Range(-10,10), Random.Range(-10, 10), 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = (targetPosition - transform.position).normalized * speed;
    }

    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -rotationSpeed));
        
        if (timeToBreak<=0)
        {
            if (!instantiated)
            {
                this.transform.localScale = new Vector3(0, 0, 0);
                Instantiate(poisonZone, transform);
                instantiated = true;
                
            }
            timeToBreak -= Time.deltaTime;

        }
        else
        {
            timeToBreak -= Time.deltaTime;
        }
        if (timeToBreak <= -0.1)
        {
            Destroy(gameObject);
        }
    }
}
