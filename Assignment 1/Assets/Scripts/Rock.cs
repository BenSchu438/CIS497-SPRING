/*
 * Benjamin Schuster
 * Assignment 1
 * Concrete class for enemies that sound like rocks
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Sound
{
    public void playSound()
    {
        Debug.Log("Crumble Crumble");
    }
}
