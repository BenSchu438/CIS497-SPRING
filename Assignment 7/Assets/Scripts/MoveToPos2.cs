/*
 * Benjamin Schuster
 * Assignment 7 - Command
 * Concrete command for lift
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPos2 : ICommand
{
    private Lift lift;

    public MoveToPos2(Lift newLift)
    {
        this.lift = newLift;
    }

    public void Execute()
    {
        lift.MoveToPos2();
    }

    public void Undo()
    {
        lift.MoveToPos1();
    }
}
