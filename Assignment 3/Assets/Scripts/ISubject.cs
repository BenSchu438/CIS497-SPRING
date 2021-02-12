/*
 * Benjamin Schuster
 * Assignment 3
 * Interface for subject object
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject 
{
    void RegisterSoldier(IObserver s);
    void UnregisterSoldier(IObserver s);
    void NewCommand(); 
}
