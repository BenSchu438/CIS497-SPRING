/*
 * Benjamin Schuster
 * Assignment 7 - Command
 * Concrete command for door
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : ICommand
{
    // private List<ICommand> commandHistory; 
    private Door door;

    public CloseDoor(Door newDoor)
    {
        this.door = newDoor;
    }
    public void Execute()
    {
        door.CloseDoor();
    }

    public void Undo()
    {
        door.OpenDoor();
    }
}
