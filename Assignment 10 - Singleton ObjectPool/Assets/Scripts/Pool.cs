/*
 * Benjamin Schuster
 * Assignment 10 - Singleton/ObjectPooler
 * Basic pool
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefab;
    public int size;
    public float lanePos;
}
