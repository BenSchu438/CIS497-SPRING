/*
 * Benjamin Schuster
 * Assignment 11
 * tracker system
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : Device
{
    public Material offStatus;
    public Material onStatus;
    public GameObject screen;

    public void EnablingTracker()
    {
        SetStatus("Establishing Tracker...");
        StartCoroutine(StartTracking());
    }
    public void DisableingTracker()
    {
        SetStatus("Disabling Tracker...");
        StartCoroutine(StopTracking());
    }

    IEnumerator StartTracking()
    {
        yield return new WaitForSeconds(3f);
        On();
    }
    IEnumerator StopTracking()
    {
        yield return new WaitForSeconds(3f);
        Off();
    }
    public override void On()
    {
        if (GetCharge() > 0)
        {
            SetStatus("On");
            screen.GetComponent<Renderer>().material = onStatus;
        }
    }

    public override void Off()
    {
        SetStatus("Off");
        screen.GetComponent<Renderer>().material = offStatus;
    }
}
