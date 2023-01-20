using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    public Sprite smallExperience;
    public Sprite mediumExperience;
    public Sprite bigExperience;

    public int experience;
    void Start()
    {
        experience = Random.Range(1,30);
        if (experience < 10)
        {
            this.GetComponent<SpriteRenderer>().sprite = smallExperience;
        }else if (experience<20)
        {
            this.GetComponent<SpriteRenderer>().sprite = mediumExperience;
        }
        else if(experience<30)
        {
            this.GetComponent<SpriteRenderer>().sprite = bigExperience;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag(Tags.player))
        {
            Destroy(this.gameObject);
            FindObjectOfType<ExperienceBarManager>().updateExperienceBar(experience);
            
        }
    }
}
