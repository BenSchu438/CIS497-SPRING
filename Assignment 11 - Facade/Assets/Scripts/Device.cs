using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Device : MonoBehaviour
{
    public string status = "Off";
    public float  charge = 100;
    public float drainRate;

    private void Awake()
    {
        StartCoroutine(BatteryDrain());
    }

    public string GetStatus()
    {
        return status;
    }
    public void SetStatus(string newStatus)
    {
        status = newStatus;
    }
    public float GetCharge()
    {
        return charge;
    }

    public abstract void On();
    public abstract void Off();

    public void EmergencyShutoff()
    {
        Off();
        charge -= drainRate * 5;
    }

    IEnumerator BatteryDrain()
    {
        while(status != "Dead")
        {
            if(status == "On")
            {
                charge -= drainRate;

                if(charge <= 0)
                    SetStatus("Dead"); 
                else
                    yield return new WaitForSeconds(3f);
            }

            yield return null;
        }
    }
}
