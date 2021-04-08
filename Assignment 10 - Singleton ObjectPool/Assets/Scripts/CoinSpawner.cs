/*
 * Benjamin Schuster
 * Assignment 10 - Singleton/ObjectPooler
 * Spawner for coins
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float spawnInterval;
    public GameObject prefab;
    public Vector3[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    IEnumerator SpawnCoin()
    {
        Vector3 nextSpawn;
        while(true)
        {
            yield return new WaitForSeconds(spawnInterval);
            nextSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(prefab, nextSpawn, prefab.transform.rotation);
        }
    }
}
