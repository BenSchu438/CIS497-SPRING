/*
 * Benjamin Schuster
 * Assignment 11
 * player controller
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public InventoryFacade inventory;

    private void Update()
    {
        // space to emergency shutdown
        if (Input.GetKeyDown(KeyCode.Space))
            inventory.EmergencyShutdown();
        // left click to turn on devices
        else if (Input.GetMouseButtonDown(0))
            inventory.PowerOn();
        // right click to turn off devices
        else if (Input.GetMouseButtonDown(1))
            inventory.PowerOff();

        else if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
