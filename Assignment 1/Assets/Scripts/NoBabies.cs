/*
 * Benjamin Schuster
 * Assignment 1
 * Concrete method for enemies that don't spawn babies when they die
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBabies : Baby
{
    public void Split(string name)
    {
        Debug.Log(name + " has died, but nothing spawned! The bloodline has ended :(");
    }
}
