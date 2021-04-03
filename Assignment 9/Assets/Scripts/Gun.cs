/*
 * Benjamin Schuster
 * Assignment 9 - State
 * Gun script, keeps track of and invokes states
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    private GameObject spawnpoint;
    public float modeCD;
    public bool switchable;

    public State currentMode;
    private State rifle;
    private State burst;
    private State sniper;
    private State shotgun;

    public TMP_Text currentModeText;

    void Start()
    {
        spawnpoint = GameObject.FindGameObjectWithTag("Barrel");
        rifle = this.GetComponent<RifleMode>();
        burst = this.GetComponent<BurstMode>();
        sniper = this.GetComponent<SniperMode>();
        shotgun = this.GetComponent<ShotgunMode>();

        currentMode = rifle;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            currentMode.Fire(spawnpoint);
            Debug.Log("Fire!");
        }

        if(Input.GetKeyDown(KeyCode.Alpha1) && switchable && currentMode != rifle)
        {
            currentMode = rifle;
            Debug.Log("Rifle mode");
            currentModeText.text = "Current Mode:\nRifle";
            StartCoroutine(SwitchCD());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && switchable && currentMode != burst)
        {
            currentMode = burst;
            Debug.Log("Burst mode");
            currentModeText.text = "Current Mode:\nBurst";
            StartCoroutine(SwitchCD());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && switchable && currentMode != sniper)
        {
            currentMode = sniper;
            Debug.Log("Sniper mode");
            currentModeText.text = "Current Mode:\nSniper";
            StartCoroutine(SwitchCD());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && switchable && currentMode != shotgun)
        {
            currentMode = shotgun;
            Debug.Log("Shotgun mode");
            currentModeText.text = "Current Mode:\nShotgun";
            StartCoroutine(SwitchCD());
        }
    }

    IEnumerator SwitchCD()
    {
        switchable = false;
        yield return new WaitForSeconds(modeCD);
        switchable = true;
    }
}
