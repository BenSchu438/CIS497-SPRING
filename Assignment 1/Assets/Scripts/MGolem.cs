/*
 * Benjamin Schuster
 * Assignment 1
 * Concrete class for medium golem enemies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGolem : Enemy
{
    public MGolem()
    {
        child = new SBabies();
        noise = new Rock();
        name = "golem";
    }

    public override void Move()
    {
        Debug.Log("The golem takes a step: ");
        noise.playSound();
    }
}
