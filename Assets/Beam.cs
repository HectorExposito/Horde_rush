using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    float speed;
    float damage;
    public static int direction;//arrows show the direction of the beam 1:<--  2:^  3:-->  4:v
    void Start()
    {
        
        transform.parent = null;
        if (direction < 4)
        {
            direction++;
        }
        else
        {
            direction = 1;
        }
        Debug.Log(direction);
        setRotation();
        damage = FindObjectOfType<BeamSpawner>().GetDamage();
        speed = FindObjectOfType<BeamSpawner>().GetSpeed();

        beamMovement();
        
    }

    private void beamMovement()
    {
        Vector3 moveDirection=new Vector3(1,0,0);
        switch (direction)
        {
            case 1:
                moveDirection = new Vector3(-1,0,0);
                break;
            case 2:
                moveDirection = new Vector3(0, 1, 0);
                break;
            case 3:
                moveDirection = new Vector3(1, 0, 0);
                break;
            case 4:
                moveDirection = new Vector3(0, -1, 0);
                break;
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = moveDirection * speed;
    }

    private void setRotation()
    {
        float rotation=0;
        switch (direction)
        {
            case 1:
                rotation = 90;
                break;
            case 2:
                rotation = 0;
                break;
            case 3:
                rotation = -90;
                break;
            case 4:
                rotation = 180;
                break;
        }
        Debug.Log(rotation);
        this.transform.rotation =Quaternion.Euler(0,0, rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.enemy))
        {
            collision.GetComponent<EnemyManager>().TakeDamage(damage);
        }
    }
}
