/*
 * Benjamin Schuster
 * Assignment 8 - Template
 * Raycast system for target selecting
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Player player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                GameObject objectHit = hitInfo.collider.gameObject;

                //if a target as been hit, set as player target
                if (objectHit.CompareTag("Enemy"))
                {
                    player.NewTarget(objectHit);
                }
            }
        }
    }
}
