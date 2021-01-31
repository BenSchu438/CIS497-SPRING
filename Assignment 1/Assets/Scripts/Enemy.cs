/*
 * Benjamin Schuster
 * Assignment 1
 * Abstract Super Class for all enemies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy 
{
    protected Baby child;
    protected Sound noise;
    protected string name;

    public abstract void Move();

    public void Die()
    {
        child.Split(name);
    }

    public string GetName()
    {
        return name;
    }


}
