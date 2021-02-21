/*
 * Benjamin Schuster
 * Assignment 4
 * Starting attack abstract class
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack 
{
    public enum Weapon { Melee, Range};

    public string description = "";
    protected Weapon weapon;
    protected int fireStrength = 0;
    protected int iceStrength = 0;

    public virtual string GetDescription()
    {
        return description;
    }

    public abstract int GetDamage();
    public abstract int GetFire();
    public abstract int GetIce();

    public virtual Weapon GetWeapon()
    {
        return weapon;
    }
}
