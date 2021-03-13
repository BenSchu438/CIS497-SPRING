/*
 * Benjamin Schuster
 * Assignment 6
 * Normal Vampire Concrete Monster
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormVamp : Enemy
{
    void Awake()
    {
        health = 15;
        speed = 6;
        damage = 13;
        cost = 15;

        SpawnCheck();
    }
}
