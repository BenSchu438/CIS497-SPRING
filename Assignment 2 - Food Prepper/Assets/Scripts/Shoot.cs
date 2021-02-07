/*
 * Benjamin Schuster
 * Assignment 2
 * raycast script for selecting food objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Food objectHit = hitInfo.collider.GetComponent<Food>();

                //if a food as been hit, and it hasn't been used yet, call its use method
                if (objectHit != null && !objectHit.beenUsed)
                {
                    objectHit.Use();
                }
            }
        }
    }
}
