/*
 * Benjamin Schuster
 * Assignment 1
 * Concrete class for wizard enemies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy
{
    public Wizard()
    {
        child = new NoBabies();
        noise = new Giggle();
        name = "wizard";
    }

    public override void Move()
    {
        Debug.Log("The wizard floats while cackling: ");
        noise.playSound();
    }
}
