/*
 * Benjamin Schuster
 * Assignment 9 - State
 * Concrete sniper state
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperMode : MonoBehaviour, State
{
    public float fireRate;
    public bool fireReady = true;

    public GameObject bullet;

    public void Fire(GameObject spawnPoint)
    {
        if (fireReady)
        {
            fireReady = false;
            Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
            StartCoroutine(FireCooldown());
        }
    }

    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireRate);
        fireReady = true;
    }
}
