/*
 * Benjamin Schuster
 * Assignment 6
 * Elite Vampire Concrete Monster
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteVamp : Enemy
{
    void Start()
    {
        health = 20;
        speed = 6;
        damage = 20;
        cost = 25;

        SpawnCheck();
    }
}
