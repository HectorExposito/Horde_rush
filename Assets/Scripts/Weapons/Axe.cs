using UnityEngine;
public class Axe : Weapon
{
    public Axe()
    {
        InitialValues();
    }


    public override void InitialValues()
    {
        weaponType = Weapon.WeaponType.Axe;
        defaultDamage = 50;
        sprite = WeaponsList.Instance.axe;
        radioGolpe = 3;
        attackDelay = 2f;
    }
}
