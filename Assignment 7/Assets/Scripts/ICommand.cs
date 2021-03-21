/*
 * Benjamin Schuster
 * Assignment 7 - Command
 * Command interface
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();
    void Undo();
}
