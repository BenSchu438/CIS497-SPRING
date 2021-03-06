/*
 * Benjamin Schuster
 * Assignment 10 - Singleton/ObjectPooler
 * Modular Lane System
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Vector3 obstaclePosition;

    public Lane leftLane;
    public Lane rightLane;

    public Lane GetLeftLane()
    {
        return leftLane;
    }
    public Lane GetRightLane()
    {
        return rightLane;
    }

    public bool HasLeftLane()
    {
        return leftLane != null;
    }
    public bool HasRightLane()
    {
        return rightLane != null;
    }
}
