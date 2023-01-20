
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public Sprite bigPotion;
    public Sprite smallPotion;
    private float health;
    float timeToPickUp;
    void Start()
    {
        timeToPickUp = 0.5f;
        int num;
        num = Random.Range(0,100);
        if (num<20)
        {
            GetComponent<SpriteRenderer>().sprite = bigPotion;
            health = 20;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = smallPotion;
            health = 10;
        }
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
            collision.GetComponent<PlayerManager>().RecoverHealth(health);
            Destroy(gameObject);
        }
    }
}
