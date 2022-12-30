using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject weaponGameObject;
    private Weapon weapon;
    public float damage;
    public float radio;
    public float delay;


    public Weapon.WeaponType weaponType;

    void Start()
    {
        initialValues();
    }

    private void initialValues()
    {
        switch (weaponType)
        {
            case Weapon.WeaponType.Axe:
                weapon = new Axe();
                break;
            case Weapon.WeaponType.Dagger:
                weapon = new Dagger();
                break;
            case Weapon.WeaponType.Sword:
                weapon = new Sword();
                break;
        }

        this.GetComponent<SpriteRenderer>().sprite = weapon.sprite;
        damage = weapon.defaultDamage;
        radio = weapon.radioGolpe;
        delay = weapon.attackDelay;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.chest))
        {
            collision.GetComponent<Animator>().SetTrigger(AnimationParametersList.openChest);
            collision.GetComponent<Chest>().spawnItem();
        }
    }

    public Weapon GetWeapon()
    {
        return weapon;
    }

    

}
