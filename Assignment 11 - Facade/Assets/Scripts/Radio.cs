using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Device
{
    public ParticleSystem visualState;

    public void OpenConnection()
    {
        SetStatus("Establishing Connection...");
        StartCoroutine(Opening());
    }
    public void CloseConnection()
    {
        SetStatus("Closing Connection...");
        StartCoroutine(Closing());
    }

    IEnumerator Opening()
    {
        yield return new WaitForSeconds(3f);
        On();
    }
    IEnumerator Closing()
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
