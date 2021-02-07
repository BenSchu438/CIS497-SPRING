/*
 * Benjamin Schuster
 * Assignment 2
 * Put on foods used exclusively on the main menu scene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFood : MonoBehaviour
{
    
    // destroy offscreen
    void Update()
    {
        if (transform.position.y <= -50)
            Destroy(gameObject);
    }
}
