/*
 * Benjamin Schuster
 * Assignment 6
 * Manage mana regeneration and UI aspects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegenMana : MonoBehaviour
{
    //variables for capping cost
    public static int magic;
    public float regenRate;
    public int manaRegened;
    public Slider slider;

    void Start()
    {
        magic = 100;
        StartCoroutine(Regen());
    }

    void Update()
    {
        slider.value = magic;
    }

    IEnumerator Regen()
    {
        while (true)
        {
            if (magic + manaRegened < 100)
                magic += manaRegened;
            else if (magic + manaRegened >= 100)
                magic = 100;
            yield return new WaitForSeconds(regenRate);
        }
    }
}
