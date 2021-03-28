/*
 * Benjamin Schuster
 * Assignment 8 - Template
 * Concrete spell class
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStorm : Spell
{
    private void Start()
    {
        spellName = "Lightning Storm";
    }

    protected override void CastSpell()
    {
        Debug.Log("LIGHTNINGSTORM! " + damage + " damage delt!");
        foreach (ParticleSystem effect in effects)
        {
            effect.Play();
        }
        FinishSpell();
    }
}
