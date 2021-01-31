/*
 * Benjamin Schuster
 * Assignment 1
 * Concrete class for enemies that spawn medium golems on death
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBabies : Baby
{
    public void Split(string name)
    {
        Debug.Log("The "+ name + " has died! Two golems have spawned!");
    }
}
