/*
 * Benjamin Schuster
 * Assignment 12 - Composite
 * Concrete clas for Character, which is a leaf object
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : TurnComponent
{
    public ParticleSystem _attackEffects;

    public override void Attack()
    {
        Debug.Log(GetName() + " attacks!");
        _attackEffects.Play();
    }

    public override string GetName()
    {
        return _name;
    }

    public override Roles GetRole()
    {
        return _role;
    }

    public override void NextTurn()
    {
        Attack();
    }
}
