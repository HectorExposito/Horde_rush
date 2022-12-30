
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

    private float damage;
    void Start()
    {
        RotationCenter = FindObjectOfType<PlayerManager>().transform;
        lifeTime = 5;
        damage = 10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.enemy))
        {
            collision.GetComponent<EnemyManager>().TakeDamage(damage);
        }
        else if (collision.CompareTag(Tags.chest))
        {
            collision.GetComponent<Animator>().SetTrigger(AnimationParametersList.openChest);
            collision.GetComponent<Chest>().spawnItem();
        }
    }
    // Update is called once per frame
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
        
        //transform.RotateAround(Vector3.zero, orbitSpeed * Time.deltaTime,Vector3.);
    }
}
