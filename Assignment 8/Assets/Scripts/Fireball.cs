/*
 * Benjamin Schuster
 * Assignment 8 - Template
 * Concrete spell class
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Spell
{
    private void Start()
    {
        spellName = "Fireball";
    }

    protected override void CastSpell()
    {
        Debug.Log("FIREBALL! " + damage + " damage delt!");
        foreach(ParticleSystem effect in effects)
        {
            effect.Play();
        }
        FinishSpell();
    }
}
