using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsList : MonoBehaviour
{
    public static WeaponsList Instance;
    public Sprite dagger;
    public Sprite sword;
    public Sprite axe;

    private void Awake()
    {
        Instance = this;
    }
    
}
