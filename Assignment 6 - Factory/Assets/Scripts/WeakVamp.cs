/*
 * Benjamin Schuster
 * Assignment 6
 * Weak Vampire Concrete Monster
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakVamp : Enemy
{
    void Awake()
    {
        health = 5;
        speed = 8;
        cost = 8;

        SpawnCheck();
    }
}
