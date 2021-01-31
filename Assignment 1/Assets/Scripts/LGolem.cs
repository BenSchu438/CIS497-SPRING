/*
 * Benjamin Schuster
 * Assignment 1
 * Concrete class for large golem enemies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGolem : Enemy
{
    public LGolem()
    {
        child = new MBabies();
        noise = new Rock();
        name = "large golem";
    }

    public override void Move()
    {
        Debug.Log("The large golem takes a heavy step: ");
        noise.playSound();
    }
}
