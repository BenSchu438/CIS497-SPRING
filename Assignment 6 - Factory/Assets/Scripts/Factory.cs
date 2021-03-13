/*
 * Benjamin Schuster
 * Assignment 6
 * Main factory abstract supertype
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    //variables for spawning
    public int minX = -6;
    public int maxX = 9;

    public void SpawnEnemy(string type)
    {
        GameObject enemy = CreateEnemy(type);

        if (enemy != null)
        {
            int ranX = Random.Range(minX, maxX);
            Vector3 pos = new Vector3(ranX, 0, 0);
            Instantiate(enemy, pos, enemy.transform.rotation);
        }
    }

    public abstract GameObject CreateEnemy(string type);
}
