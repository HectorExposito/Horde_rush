using UnityEngine;

public class Sword : Weapon
{
    public Sword()
    {
        InitialValues();
    }

    public override void InitialValues()
    {
        weaponType = Weapon.WeaponType.Sword;
        defaultDamage = 20;
        sprite = WeaponsList.Instance.sword;
        radioGolpe = 2;
        attackDelay = 0.5f;
    }
}
