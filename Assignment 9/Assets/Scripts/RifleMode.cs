/*
 * Benjamin Schuster
 * Assignment 9 - State
 * Concrete rifle state
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleMode : MonoBehaviour, State
{
    public float fireRate;
    public bool fireReady = true;

    public float spreadAngle;

    public GameObject bullet;

    public void Fire(GameObject spawnPoint)
    {
        if(fireReady)
        {
            fireReady = false;

            // random bullet deviation
            Quaternion nextRot;
            nextRot = new Quaternion(
                        spawnPoint.transform.rotation.x + (Random.Range(-spreadAngle, spreadAngle)),
                        spawnPoint.transform.rotation.y + (Random.Range(-spreadAngle, spreadAngle)),
                        spawnPoint.transform.rotation.z,
                        spawnPoint.transform.rotation.w);


            Instantiate(bullet, spawnPoint.transform.position, nextRot);
            StartCoroutine(FireCooldown());
        }
    }

    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireRate);
        fireReady = true;
    }
}
