
using System;
using UnityEngine;

public abstract class Weapon
{
    public Sprite sprite;
    public float defaultDamage;
    public WeaponType weaponType;
    public float radioGolpe;
    public float attackDelay;


    public abstract void InitialValues();

    public enum WeaponType
    {
        Dagger,
        Axe,
        Sword
    }
}

