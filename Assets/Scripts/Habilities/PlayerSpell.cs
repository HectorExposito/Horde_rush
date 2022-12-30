using UnityEngine;

public class PlayerSpell : MonoBehaviour
{
    float speed;
    float damage;
    private Vector3 targetPosition;
    public float rotationSpeed;
    void Start()
    {
        damage = FindObjectOfType<Wand>().GetDamage();
        speed = FindObjectOfType<Wand>().GetSpeed();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.enemy);
        int num=Random.Range(0,enemies.Length-1);
        targetPosition = new Vector3(Random.Range(-100,100), Random.Range(-100, 100),0);
        gameObject.GetComponent<Rigidbody2D>().velocity = (targetPosition - transform.position).normalized*speed;
    }

    
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -rotationSpeed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.enemy))
        {
            collision.GetComponent<EnemyManager>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag(Tags.chest))
        {
            collision.GetComponent<Animator>().SetTrigger(AnimationParametersList.openChest);
            collision.GetComponent<Chest>().spawnItem();
        }

    }
}
