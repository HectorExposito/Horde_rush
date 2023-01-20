using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float previousSpeed;
    private float distance;
    public float wizardDistance;
    private bool movement=true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }
    void Update()
    {
        Vector3 direction = new Vector3(0,0,0);
        if (player!=null)
        {
            direction = player.transform.position - transform.position;
        }
        if (player != null)
        {
            if (GetComponent<WizardManager>() != null)
            {
                distance = direction.magnitude;
                if (Mathf.Abs(distance) < wizardDistance)
                {
                    movement = false;
                }
                else if (movement == false)
                {
                    movement = true;
                }
            }

            if (movement)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
        
    }

    public float GetDistance()
    {
        return distance;
    }

    internal void slowDown()
    {
        previousSpeed = speed;
        speed = speed / 4;
    }

    internal void setDefaultSpeed()
    {
        speed = previousSpeed;
    }
}
