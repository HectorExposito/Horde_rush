using UnityEngine;

public class Dagger : Weapon
{
    public Dagger()
    {
        InitialValues();
    }


    public override void InitialValues()
    {
        weaponType = Weapon.WeaponType.Dagger;
        defaultDamage = 5;
        sprite = WeaponsList.Instance.dagger;
        radioGolpe = 1;
        attackDelay = 1f;
    }
}
