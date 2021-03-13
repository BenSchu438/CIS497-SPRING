/*
 * Benjamin Schuster
 * Assignment 6
 * Weak Zombie Concrete Monster
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakZombie : Enemy
{
    void Awake()
    {
        health = 10;
        damage = 5;
        cost = 5;

        SpawnCheck();
    }
}
