/*
 * Benjamin Schuster
 * Assignment 8 - Template
 * Concrete Spell System
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashFreeze : Spell
{
    private void Start()
    {
        spellName = "Flash Freeze";
    }

    protected override void CastSpell()
    {
        Debug.Log("FLASHFREEZE! " + damage + " damage delt!");
        foreach (ParticleSystem effect in effects)
        {
            effect.Play();
        }
        FinishSpell();
    }
}
