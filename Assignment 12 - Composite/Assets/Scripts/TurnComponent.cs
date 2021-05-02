/*
 * Benjamin Schuster
 * Assignment 12 - Composite
 * The supertype for the composite pattern
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurnComponent : MonoBehaviour
{
    public enum Roles
    {
        Character,
        Team,
    }

    public Roles _role;
    public string _name;

    public abstract Roles GetRole();
    public abstract string GetName();
    public abstract void NextTurn();
    
    public virtual void Add(TurnComponent member)
    {
        Debug.Log(_role + " does not support Add()");
    }
    public virtual void Remove(TurnComponent member)
    {
        Debug.Log(_role + " does not support Remove()");
    }

    public virtual void Attack()
    {
        Debug.Log(_role + " does not support Attack()");
    }
}
