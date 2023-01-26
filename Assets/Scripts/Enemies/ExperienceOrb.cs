using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    public ExperienceSize experienceSize;

    public int experience;
    void Start()
    {
        switch (experienceSize)
        {
            case ExperienceSize.SMALL:
                experience = 10;
                break;
            case ExperienceSize.MEDIUM:
                experience = 20;
                break;
            case ExperienceSize.BIG:
                experience = 30;
                break;
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

    public enum ExperienceSize
    {
        BIG,MEDIUM,SMALL
    }
}
