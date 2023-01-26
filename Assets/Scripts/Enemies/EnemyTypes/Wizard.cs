

public class Wizard : Enemy
{
    public Wizard(EnemyType enemyType)
    {
        InitialValues(enemyType);
    }
    public override void InitialValues(EnemyType enemyType)
    {
        health = 30;
        speed = 1;
        damage = 7;
        attackDelay = 3;
        sprite = EnemiesList.instance.GetSprite(enemyType);
    }
}
