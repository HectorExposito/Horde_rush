
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public Sprite bigPotion;
    public Sprite smallPotion;
    private float health;
    void Start()
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.player))
        {
            collision.GetComponent<PlayerManager>().RecoverHealth(health);
            Destroy(gameObject);
        }
    }
}
