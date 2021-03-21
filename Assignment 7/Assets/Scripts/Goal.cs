/*
 * Benjamin Schuster
 * Assignment 7 - Command
 * Goal particle script
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public ParticleSystem reward;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            reward.Play();
    }
}
