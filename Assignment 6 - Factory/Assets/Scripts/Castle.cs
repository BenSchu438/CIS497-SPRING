/*
 * Benjamin Schuster
 * Assignment 6
 * Castle factory that controls spawning vampire enemies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Factory
{
    // prefab for vampires
    public GameObject weakVamp;
    public GameObject normVamp;
    public GameObject eliteVamp;

    public override GameObject CreateEnemy(string type)
    {
        GameObject temp = null;

        if (type.Equals("Weak"))
        {
            temp = weakVamp;
        }
        else if (type.Equals("Norm"))
        {
            temp = normVamp;
        }
        else if (type.Equals("Elite"))
        {
            temp = eliteVamp;
        }

        return temp;
    }
}
