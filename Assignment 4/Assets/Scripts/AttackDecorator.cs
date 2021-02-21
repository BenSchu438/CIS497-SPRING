/*
 * Benjamin Schuster
 * Assignment 4
 * Abstract supertype for attack decorators (spell enchanatments) 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackDecorator : Attack
{
    public override abstract string GetDescription();

    public override abstract Weapon GetWeapon();
}
