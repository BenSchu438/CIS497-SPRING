/*
 * Benjamin Schuster
 * Assignment 7 - Command
 * Door device
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool opened;

    void Awake()
    {
        opened = false;
    }

    public void OpenDoor()
    {
        Debug.Log("Open Door");
        opened = true;
        this.gameObject.SetActive(false);
    }
    public void CloseDoor()
    {
        Debug.Log("Close Door");
        opened = false;
        this.gameObject.SetActive(true);
    }
    
}
