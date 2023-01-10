using UnityEngine;

public class ShurikenSpawner : MonoBehaviour
{
    public GameObject shuriken;
    private float delay;
    private float actualDelay;
    public int level;
    int numberOfShurikens;
    void Start()
    {
        level = 1;
        delay = 10;
        actualDelay = delay;
    }

    void Update()
    {
        if (actualDelay <= 0)
        {
            for (int i = 0; i < numberOfShurikens; i++)
            {
                Instantiate(shuriken, transform);
            }
            
            actualDelay = delay;
        }
        else
        {
            actualDelay -= Time.deltaTime;
        }
    }

    internal void levelUp()
    {
        level++;
        setValues();
    }

    private void setValues()
    {
        switch (level)
        {
            case 1:
                numberOfShurikens = 1;
                break;
            case 2:
                numberOfShurikens = 2;
                break;
            case 3:
                delay = 7;
                break;
            case 4:
                numberOfShurikens = 3;
                delay = 5;
                break;
            case 5:
                numberOfShurikens = 4;
                break;
        }
    }
}
