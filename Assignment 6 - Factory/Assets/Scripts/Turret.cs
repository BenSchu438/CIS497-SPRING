/*
 * Benjamin Schuster
 * Assignment 5
 * Turret script that attacks frontmost zombies
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject[] zombies;
    private GameObject target;
    private float minDist;
    public int damage = 15;
    public float attackSpeed = 1f;
    public float targetSpeed = 3f;

    private void Start()
    {
        StartCoroutine(Target());
        StartCoroutine(Attack());
    }

    protected IEnumerator Attack()
    {
        while (true)
        {
            //if theres a zombie, attack it
            if (target != null)
            {
                //Debug.Log("attacking!");
                target.GetComponent<Enemy>().Damaged(damage);
            }
            //wait before attacking again
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    protected IEnumerator Target()
    {
        while(true)
        {
            //Debug.Log("Targeting...");
            //select closest zombie
            zombies = GameObject.FindGameObjectsWithTag("Enemy");
            minDist = -1000;
            foreach (GameObject zom in zombies)
            {
                if (zom.transform.position.z > minDist)
                {
                    minDist = zom.transform.position.z;
                    target = zom;
                }
            }

            yield return new WaitForSeconds(targetSpeed);
        }
    }
}
