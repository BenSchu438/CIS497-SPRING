/*
 * Benjamin Schuster
 * Assignment 6
 * Normal Zombie Concrete Monster
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormZombie : Enemy
{
    void Awake()
    {
        health = 20;
        speed = 4;
        damage = 8;
        cost = 10;

        SpawnCheck();
    }
}
