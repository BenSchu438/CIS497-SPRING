/*
 * Benjamin Schuster
 * Assignment 10 - Singleton/ObjectPooler
 * Controls movement and requeueing of road segments
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRoad : MonoBehaviour
{
    public string tag;
    public float speed;
    public float requeueZ;
    public float lanePos;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
        
    }
    private void FixedUpdate()
    {
        if (transform.position.z < requeueZ)
        {
            RoadPooler.instance.ResetRoadFromPool(tag, lanePos);
        }
    }
}
