/*
 * Benjamin Schuster
 * Assignment 11
 * Flashlight System
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Device
{
    public ParticleSystem visualState;

    public void WarmingUp()
    {
        SetStatus("Warming up...");
        StartCoroutine(WarmUp());
    }
    public void ShuttingDown()
    {
        SetStatus("Shutting down...");
        StartCoroutine(ShutDown());
    }

    IEnumerator WarmUp()
    {
        yield return new WaitForSeconds(3f);
        On();
    }
    IEnumerator ShutDown()
    {
        yield return new WaitForSeconds(3f);
        Off();
    }

    public override void On()
    {
        if (GetCharge() > 0)
        {
            SetStatus("On");
            visualState.Play();
        }
    }

    public override void Off()
    {
        SetStatus("Off");
        visualState.Stop();
    }
}
