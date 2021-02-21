/*
 * Benjamin Schuster
 * Assignment 4
 * Concrete decorator for fire, sets target on fire
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDecorator : AttackDecorator
{
    Attack attack;

    public FireDecorator(Attack a)
    {
        this.attack = a;
    }

    public override int GetDamage()
    {
        return attack.GetDamage();
    }

    public override Weapon GetWeapon()
    {
        return attack.GetWeapon();
    }

    public override string GetDescription()
    {
        return "-Burning\n" + attack.GetDescription();
    }

    //Fire doesn't add ice
    public override int GetFire()
    {
        return attack.GetFire()+25;
    }
    public override int GetIce()
    {
        return attack.GetIce();
    }
}
