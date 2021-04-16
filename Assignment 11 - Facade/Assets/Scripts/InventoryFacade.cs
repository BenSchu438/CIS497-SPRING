/*
 * Benjamin Schuster
 * Assignment 11
 * Facade for all inventory tools
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryFacade : MonoBehaviour
{
    public Flashlight flashlight;
    public Tracker tracker;
    public Radio radio;
    public Text flashlightTxt;
    public Text trackerTxt;
    public Text radioTxt;

    public bool working = false;

    // turn things on after 3 seconds
    public void PowerOn()
    {
        if(!working)
        {
            
            if (flashlight.GetStatus() == "Off")
            {
                StartCoroutine(Work());
                flashlight.WarmingUp();
            }

            if (tracker.GetStatus() == "Off")
            {
                StartCoroutine(Work());
                tracker.EnablingTracker();
            }

            if (radio.GetStatus() == "Off")
            {
                StartCoroutine(Work());
                radio.OpenConnection();
            }
        }
    }

    // turn things off after 3 seconds
    public void PowerOff()
    {
        if(!working)
        {
            
            if (flashlight.GetStatus() == "On")
            {
                StartCoroutine(Work());
                flashlight.ShuttingDown();
            }

            if (tracker.GetStatus() == "On")
            {
                StartCoroutine(Work());
                tracker.DisableingTracker();
            }

            if (radio.GetStatus() == "On")
            {
                StartCoroutine(Work());
                radio.CloseConnection();
            }
        }
        
    }

    // instantly turn things off
    public void EmergencyShutdown()
    {
        if(!working)
        {
            if (flashlight.GetStatus() == "On")
            {
                flashlight.EmergencyShutoff();
            }

            if (tracker.GetStatus() == "On")
            {
                tracker.EmergencyShutoff();
            }

            if (radio.GetStatus() == "On")
            {
                radio.EmergencyShutoff();
            }
        }
    }

    //Get status of all devices
    public void StatusCheck()
    {
        string flashlightStatus = "Flashlight Status: " + flashlight.GetStatus() + "\nCharge: " + flashlight.GetCharge();
        string trackerStatus = "Tracker Status: " + tracker.GetStatus() + "\nCharge: " + tracker.GetCharge();
        string radioStatus = "Radio Status: " + radio.GetStatus() + "\nCharge: " + radio.GetCharge();

        flashlightTxt.text = flashlightStatus;
        trackerTxt.text = trackerStatus;
        radioTxt.text = radioStatus;
    }

    IEnumerator Work()
    {
        working = true;
        yield return new WaitForSeconds(3f);
        working = false;
    }

    private void FixedUpdate()
    {
        StatusCheck();
    }
}
