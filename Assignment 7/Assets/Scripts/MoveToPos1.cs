/*
 * Benjamin Schuster
 * Assignment 7 - Command
 * Concrete command for lift
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPos1 : ICommand
{
    private Lift lift;

    public MoveToPos1(Lift newLift)
    {
        this.lift = newLift;
    }

    public void Execute()
    {
        lift.MoveToPos1();
    }

    public void Undo()
    {
        lift.MoveToPos2();
    }
}
