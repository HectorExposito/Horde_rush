
using System;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public Transform RotationCenter;
    public float rotationSpeed;
    public float orbitSpeed;
    public float radius;
    private float posX;
    private float posY;
    private float angle;
    private float lifeTime;
    static int numberOfShuriken=1;
    public int s;
    private float damage;
    void Start()
    {
        RotationCenter = FindObjectOfType<PlayerManager>().transform;
        Debug.Log(transform.position);
        lifeTime = 5;
        damage = 10;
        setInitialPosition();
    }

    private void setInitialPosition()
    {
        if (numberOfShuriken < 4)
        {
            numberOfShuriken++;
        }
        else
        {
            numberOfShuriken = 1;
        }
        s = numberOfShuriken;
        switch (numberOfShuriken)
        {
            case 1:
                angle = 0;
                break;
            case 2:
                angle = 1.5f;
                break;
            case 3:
                angle = 3;
                break;
            case 4:
                angle = -1.5f;
                break;
        }
        Debug.Log(angle);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        switch (collision.tag)
        {
            case Tags.enemy:
                collision.GetComponent<EnemyManager>().TakeDamage(damage);
                break;
            case Tags.chest:
                collision.GetComponent<Animator>().SetTrigger(AnimationParametersList.openChest);
                collision.GetComponent<Chest>().spawnItem();
                break;
            case Tags.spell:
                Destroy(collision.gameObject);
                break;
        }
    }

    void Update()
    {
        if (lifeTime >= 0)
        {
            transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime));
            posX = RotationCenter.position.x + Mathf.Cos(angle) * radius;
            posY = RotationCenter.position.y + Mathf.Sin(angle) * radius;
            transform.position = new Vector2(posX, posY);
            angle = angle + Time.deltaTime * orbitSpeed;

            if (angle >= 360)
            {
                angle = 0;
            }
            lifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
