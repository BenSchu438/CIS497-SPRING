/*
 * Benjamin Schuster
 * Assignment 6
 * Elite Zombie Concrete Monster
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteZombie : Enemy
{
    void Awake()
    {
        health = 60;
        speed = 3;
        damage = 15;
        cost = 20;

        SpawnCheck();
    }
}
