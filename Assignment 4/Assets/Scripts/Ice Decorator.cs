/*
 * Benjamin Schuster
 * Assignment 4
 * Concrete decorator for ice, freezes target
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDecorator : AttackDecorator
{
    Attack attack;

    public IceDecorator(Attack a)
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
        return "-Freezing\n" + attack.GetDescription();
    }

    //Ice doesn't add fire
    public override int GetFire()
    {
        return attack.GetFire();
    }
    public override int GetIce()
    {
        return attack.GetIce() + 25;
    }
}
