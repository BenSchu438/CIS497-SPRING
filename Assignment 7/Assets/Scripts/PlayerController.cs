/*
 * Benjamin Schuster
 * Assignment 7
 * Player controller
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // basic movement
    private float horizontalInput;
    private float verticalInput;
    public float speed = 5;
    public float maxSpeed = 50;
    private Rigidbody rb;

    // Command pattern stuff
    public TerminalInvoker linkedTerminal;
    private TerminalInvoker closestTerminal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Basic player movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.rotation = Quaternion.LookRotation(movement);
        if ((horizontalInput != 0 || verticalInput != 0))
        {
            rb.AddForce(transform.forward * speed, ForceMode.Force);
        }
        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
    }

    void Update()
    {
        
        // Press E to invoke invokers command
        if (Input.GetKeyDown(KeyCode.E) && linkedTerminal != null)
        {
            linkedTerminal.ExecuteDoor();
            linkedTerminal.ExecuteLift();
        }
            
        // Press Q to invoke invokers undo 
        if (Input.GetKeyDown(KeyCode.Q) && linkedTerminal != null)
            linkedTerminal.Undo();

        // Press tab near terminal to link, allowing controls
        if (Input.GetKeyDown(KeyCode.Tab) && closestTerminal != null)
        {
            // Unlink old terminal
            if (linkedTerminal != null)
                linkedTerminal.Unlink();

            // Link w. new terminal
            linkedTerminal = closestTerminal;
            linkedTerminal.Link();
        }

        // put player back on ground if off map
        if (transform.position.y < -3)
            transform.position = new Vector3(0, 1, 0);

        // restart scene with r
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // manage if player is close enough to an terminal to offer link
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terminal"))
            closestTerminal = other.GetComponent<TerminalInvoker>();
        else if (other.CompareTag("Platform"))
            transform.parent = other.transform;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Terminal"))
            closestTerminal = null;
        else if (other.CompareTag("Platform"))
            transform.parent = null;
    }

}
