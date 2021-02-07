/*
 * Benjamin Schuster
 * Assignment 2
 * Empty tool for when no buttons are pressed
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : Tool
{
    public override int Correct(Food f)
    {
        Debug.Log("No tool equipped!");
        return 2;
    }
}
