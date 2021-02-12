/*
 * Benjamin Schuster
 * Assignment 3
 * Interface for observer objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void NewOrder(string order);
}
