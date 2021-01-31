/*
 * Benjamin Schuster
 * Assignment 1
 * Concrete class for small golem enemies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGolem : Enemy
{
    public SGolem()
    {
        child = new NoBabies();
        noise = new Rock();
        name = "small golem";
    }

    public override void Move()
    {
        Debug.Log("The small golem rolls foward: ");
        noise.playSound();
    }
}
