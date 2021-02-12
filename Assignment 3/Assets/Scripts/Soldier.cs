/*
 * Benjamin Schuster
 * Assignment 3
 * Concrete observer class, equip weapon based off command. Soldier themed
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour, IObserver
{
    public GameObject spear;
    public GameObject shield;
    public GameObject bow;

    public void NewOrder(string order)
    {
        //equip correct weapon depending on command
        if(order.Equals("Melee"))
        {
            spear.SetActive(true);
            shield.SetActive(false);
            bow.SetActive(false);
        }
        else if(order.Equals("Range"))
        {
            spear.SetActive(false);
            shield.SetActive(false);
            bow.SetActive(true);
        }
        else if (order.Equals("Defend"))
        {
            spear.SetActive(false);
            shield.SetActive(true);
            bow.SetActive(false);
        }
        else if (order.Equals("Holster"))
        {
            spear.SetActive(false);
            shield.SetActive(false);
            bow.SetActive(false);
        }
    }
}
