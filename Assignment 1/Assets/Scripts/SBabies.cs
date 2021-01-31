/*
 * Benjamin Schuster
 * Assignment 1
 * Concrete class for enemies that spawn small golems on death
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBabies : Baby
{
    public void Split(string name)
    {
        Debug.Log("The "+ name + " has died! Two small golems have spawned!");
    }
}
