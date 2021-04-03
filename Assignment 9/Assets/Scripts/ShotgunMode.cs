/*
 * Benjamin Schuster
 * Assignment 9 - State
 * Concrete shotgun state
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunMode : MonoBehaviour, State
{
    public float fireRate;
    public float deviationAngle = 0.05f;
    public bool fireReady = true;

    public GameObject bullet;

    public void Fire(GameObject spawnPoint)
    {
        if (fireReady)
        {
            fireReady = false;

            //Spawn 9 pellets w/ deviating angles
            Quaternion nextRot;
            for(int i = -1; i < 2; i++)
            {
                for(int j = -1; j < 2; j++)
                {
                    // set 3 by 3 pattern
                    nextRot = new Quaternion(
                        spawnPoint.transform.rotation.x + (i * deviationAngle),
                        spawnPoint.transform.rotation.y + (j * deviationAngle),
                        spawnPoint.transform.rotation.z,
                        spawnPoint.transform.rotation.w);

                    // randomly angled pellets 
                    //nextRot = new Quaternion(
                    //    spawnPoint.transform.rotation.x + (Random.Range(-deviationAngle, deviationAngle)),
                    //    spawnPoint.transform.rotation.y + (Random.Range(-deviationAngle, deviationAngle)),
                    //    spawnPoint.transform.rotation.z,
                    //    spawnPoint.transform.rotation.w);

                    Instantiate(bullet, spawnPoint.transform.position, nextRot );
                }
            }


            StartCoroutine(FireCooldown());
        }
    }

    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireRate);
        fireReady = true;
    }
}
