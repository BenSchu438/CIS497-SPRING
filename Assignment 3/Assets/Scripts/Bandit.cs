/*
 * Benjamin Schuster
 * Assignment 3
 * Concrete observer class, equip weapon based off command. bandit themed
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : MonoBehaviour, IObserver
{
    public GameObject sword;
    public GameObject shield;
    public GameObject crossbow;

    public void NewOrder(string order)
    {
        //equip correct weapon depending on command
        if(order.Equals("Melee"))
        {
            sword.SetActive(true);
            shield.SetActive(false);
            crossbow.SetActive(false);
        }
        else if(order.Equals("Range"))
        {
            sword.SetActive(false);
            shield.SetActive(false);
            crossbow.SetActive(true);
        }
        else if (order.Equals("Defend"))
        {
            sword.SetActive(false);
            shield.SetActive(true);
            crossbow.SetActive(false);
        }
        else if (order.Equals("Holster"))
        {
            sword.SetActive(false);
            shield.SetActive(false);
            crossbow.SetActive(false);
        }
    }
}
