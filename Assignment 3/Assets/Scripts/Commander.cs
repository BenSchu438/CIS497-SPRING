/*
 * Benjamin Schuster
 * Assignment 3
 * Concrete class for subject class, commander issues new orders, player input
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour, ISubject
{
    private List<IObserver> soldiers = new List<IObserver>();

    //list of commands to choose from
    private readonly string melee = "Melee";
    private readonly string range = "Range";
    private readonly string defend = "Defend";
    private readonly string holster = "Holster";

    //current command
    private string currentCommand;

    private void Start()
    {
        //Holster as default command
        currentCommand = holster;
    }

    public void NewCommand()
    {
        if(soldiers != null)
        {
            foreach (IObserver s in soldiers)
            {
                s.NewOrder(currentCommand);
            }
        }
        
    }

    public void RegisterSoldier(IObserver s)
    {
        if (soldiers != null && !soldiers.Contains(s))
            soldiers.Add(s);
        else
            Debug.Log("Soldier already registered");
    }

    public void UnregisterSoldier(IObserver s)
    {
        if(soldiers != null)
        {
            if (soldiers.Contains(s))
                soldiers.Remove(s);
            else
                Debug.Log("Soldier already unregistered");
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            //issue melee attack command
            currentCommand = melee;
            NewCommand();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            //issue ranged attack command
            currentCommand = range;
            NewCommand();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            //issue defend command
            currentCommand = defend;
            NewCommand();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //issue stand down command
            currentCommand = holster;
            NewCommand();
        }
    }

}
