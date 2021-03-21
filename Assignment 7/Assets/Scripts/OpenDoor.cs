/*
 * Benjamin Schuster
 * Assignment 7 - Command
 * concrete command for door
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : ICommand
{
    // private List<ICommand> commandHistory;
    private Door door;

    public OpenDoor(Door newDoor)
    {
        this.door = newDoor;
    }

    public void Execute()
    {
        door.OpenDoor();
    }

    public void Undo()
    {
        door.CloseDoor();
    }
}
