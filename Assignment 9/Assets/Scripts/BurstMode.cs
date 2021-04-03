/*
 * Benjamin Schuster
 * Assignment 9 - State
 * Concrete burst state
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstMode : MonoBehaviour, State
{
    public float fireRate;
    public float burstRate = 0.1f;
    public int burstCount = 3;
    public bool fireReady = true;

    public GameObject bullet;

    public void Fire(GameObject spawnPoint)
    {
        if (fireReady)
        {
            fireReady = false;
            StartCoroutine(BurstFire(spawnPoint));
            StartCoroutine(FireCooldown());
        }
    }

    IEnumerator BurstFire(GameObject spawnPoint)
    {
        int count = 0;
        while (count < burstCount)
        {
            Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
            count++;
            yield return new WaitForSeconds(burstRate);
        }
    }

    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireRate);
        fireReady = true;
    }
}
