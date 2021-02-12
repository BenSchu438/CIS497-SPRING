/*
 * Benjamin Schuster
 * Assignment 3
 * Used to select people to register and unregister
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public GameObject commander;


    // Update is called once per frame
    void Update()
    {
        //register soldier on mouse 1 click
        if(Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit person;

            if(Physics.Raycast(rayOrigin, out person))
            {
                IObserver selected = person.collider.GetComponent<IObserver>();
                if(selected != null)
                {
                    commander.GetComponent<Commander>().RegisterSoldier(selected);
                }
            }
        }
        //unregister soldier on mouse 2 click
        else if(Input.GetMouseButtonDown(1))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit person;

            if (Physics.Raycast(rayOrigin, out person))
            {
                IObserver selected = person.collider.GetComponent<IObserver>();
                if (selected != null)
                {
                    commander.GetComponent<Commander>().UnregisterSoldier(selected);
                }
            }
        }
    }
}
