/*
 * Benjamin Schuster
 * Assignment 4
 * Concrete decorator for power, increases damage
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDecorator : AttackDecorator
{
    Attack attack;

    public PowerDecorator(Attack a)
    {
        this.attack = a;
    }

    public override int GetDamage()
    {
        return attack.GetDamage() + 15;
    }

    public override Weapon GetWeapon()
    {
        return attack.GetWeapon();
    }

    public override string GetDescription()
    {
        return "-Empowered\n" + attack.GetDescription();
    }

    //Power doesn't add fire or ice
    public override int GetFire()
    {
        return attack.GetFire();
    }
    public override int GetIce()
    {
        return attack.GetIce();
    }
}
