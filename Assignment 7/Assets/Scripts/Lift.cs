/*
 * Benjamin Schuster
 * Assignment 7 - Command
 * Lift device
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;
    public float waitTime;

    public bool atpos1;
    public bool liftReady;

    void Awake()
    {
        atpos1 = true;
        liftReady = true;
    }

    public void MoveToPos1()
    {
        liftReady = false;
        StartCoroutine(MovePlatform(pos2, pos1));
        atpos1 = true;
    }
    public void MoveToPos2()
    {
        liftReady = false;
        StartCoroutine(MovePlatform(pos1, pos2));
        atpos1 = false;
    }

    IEnumerator MovePlatform(Vector3 startPos, Vector3 endPos)
    {
        float time = 0;
        while(time < waitTime)
        {
            time += Time.deltaTime;

            transform.position = Vector3.Lerp(startPos, endPos, time / waitTime);

            yield return null;
        }
        transform.position = endPos;
        liftReady = true;
    }
}
