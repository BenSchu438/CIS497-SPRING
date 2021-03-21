/*
 * Benjamin Schuster
 * Assignment 7 - Command
 * Invoker
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalInvoker : MonoBehaviour
{
    private Stack<ICommand> commandHistory;
    public Door door;
    public Lift lift;
    private OpenDoor openCommand;
    private CloseDoor closeCommand;
    private MoveToPos1 pos1Command;
    private MoveToPos2 pos2Command;


    public Material unlinkedMat;
    public Material linkedMat;

    void Awake()
    {
        commandHistory = new Stack<ICommand>();
        
        // if a door invoker, create commands
        if (door != null)
        {
            openCommand = new OpenDoor(door);
            closeCommand = new CloseDoor(door);
        }

        // if a lift invoker, create commands
        if (lift != null)
        {
            pos1Command = new MoveToPos1(lift);
            pos2Command = new MoveToPos2(lift);
        }
    }

    // Open the door
    public void ExecuteDoor()
    {
        if(door != null)
        {
            if (!door.opened)
            {
                commandHistory.Push(openCommand);
                openCommand.Execute();
            }
            else
            {
                commandHistory.Push(closeCommand);
                closeCommand.Execute();
            }
        }
        
    }
    // Move the lift
    public void ExecuteLift()
    {
        if(lift !=null)
        {
            if (!lift.atpos1 && lift.liftReady)
            {
                commandHistory.Push(pos1Command);
                pos1Command.Execute();
            }
            else if(lift.liftReady)
            {
                commandHistory.Push(pos2Command);
                pos2Command.Execute();
            }
        }
    }

    // call undo on linked door
    public void Undo()
    {
        if (commandHistory.Count != 0)
        {
            ICommand lastCommand = commandHistory.Pop();
            lastCommand.Undo();
        }
        else
            Debug.Log("No commands to undo");
    }

    // Methods for linking and unlinking. Color changes only
    public void Link()
    {
        this.GetComponent<MeshRenderer>().material = linkedMat;
    }
    public void Unlink()
    {
        this.GetComponent<MeshRenderer>().material = unlinkedMat ;
    }
}
