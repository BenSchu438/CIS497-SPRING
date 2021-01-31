/*
 * Benjamin Schuster
 * Assignment 1
 * Concrete class for skeleton enemies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public Skeleton()
    {
        child = new NoBabies();
        noise = new Bone();
        name = "skeleton";
    }

    public override void Move()
    {
        Debug.Log("The skeleton stumbles forward: ");
        noise.playSound();
    }

}
