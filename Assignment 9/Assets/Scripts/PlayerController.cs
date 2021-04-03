/*
 * Benjamin Schuster
 * Assignment 9 - State
 * Controls player movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    void Update()
    {
        //check input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //move player forward
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}