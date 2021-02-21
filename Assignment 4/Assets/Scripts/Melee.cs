/*
 * Benjamin Schuster
 * Assignment 4
 * Concrete attack class for Melee
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Attack
{
    public Melee()
    {
        this.description = "Slash";
        this.weapon = Weapon.Melee;
    }
    public override int GetDamage()
    {
        return 20;
    }

    //weapons don't have natural fire or ice damage
    public override int GetFire()
    {
        return 0;
    }
    public override int GetIce()
    {
        return 0;
    }
}
