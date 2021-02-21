/*
 * Benjamin Schuster
 * Assignment 4
 * Concrete attack class for Range
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : Attack
{
    public Range()
    {
        this.description = "Shot";
        this.weapon = Weapon.Range;
    }
    public override int GetDamage()
    {
        return 10;
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
