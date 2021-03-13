/*
 * Benjamin Schuster
 * Assignment 6
 * Graveyard factory that controls spawning zombie enemies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : Factory
{
    // prefab for zombies
    public GameObject weakZom;
    public GameObject normZom;
    public GameObject eliteZom;

    public override GameObject CreateEnemy(string type)
    {
        GameObject temp = null;

        if(type.Equals("Weak"))
        {
            temp = weakZom;
        }
        else if(type.Equals("Norm"))
        {
            temp = normZom;
        }
        else if (type.Equals("Elite"))
        {
            temp = eliteZom;
        }

        return temp;
    }
}
