/*
 * Benjamin Schuster
 * Assignment 5
 * Main zombie factory that creates appropriate zombie
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFactory : MonoBehaviour
{
    public GameObject simplePre;
    public GameObject zoomerPre;
    public GameObject chonkerPre;
    public GameObject stabberPre;

    public int simpleCost;
    public int ZoomerCost;
    public int chonkerCost;
    public int stabberCost;

    public GameObject CreateZombie(string t)
    {
        GameObject zombie = null;

        if (t.Equals("Simple") && (Graveyard.magic - simpleCost >= 0))
        {
            zombie = simplePre;
            Graveyard.magic -= simpleCost;
        }
        else if (t.Equals("Zoomer") && (Graveyard.magic - ZoomerCost >= 0))
        {
            zombie = zoomerPre;
            Graveyard.magic -= ZoomerCost;
        }
        else if (t.Equals("Chonker") && (Graveyard.magic - chonkerCost >= 0))
        {
            zombie = chonkerPre;
            Graveyard.magic -= chonkerCost;
        }
        else if (t.Equals("Stabber") && (Graveyard.magic - stabberCost >= 0))
        {
            zombie = stabberPre;
            Graveyard.magic -= stabberCost;
        }

        return zombie;
    }
}
