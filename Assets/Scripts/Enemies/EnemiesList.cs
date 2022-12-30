using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesList : MonoBehaviour
{
    public static EnemiesList instance;
    public Sprite wizard;
    public Sprite spider;
    public Sprite rat;
    public Sprite bat;
    public Sprite ghost;
    public Sprite warrior;

    private void Awake()
    {
        instance = this;
    }
    public Sprite GetSprite(Enemy.EnemyType enemy)
    {
        switch (enemy)
        {
            case Enemy.EnemyType.Wizard:
                return wizard;
            case Enemy.EnemyType.Spider:
                return spider;
            case Enemy.EnemyType.Bat:
                return bat;
            case Enemy.EnemyType.Warrior:
                return warrior;
            case Enemy.EnemyType.Ghost:
                return ghost;
            case Enemy.EnemyType.Rat:
                return rat;
        }
        return null;
    }
}
