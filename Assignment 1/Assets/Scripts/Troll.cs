/*
 * Benjamin Schuster
 * Assignment 1
 * Concrete class for Troll enemies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : Enemy
{
    public Troll()
    {
        child = new NoBabies();
        noise = new Rock();
        name = "troll";
    }

    public override void Move()
    {
        Debug.Log("Troll lazily walks forward");
        noise.playSound();
    }
}
