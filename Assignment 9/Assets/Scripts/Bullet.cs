/*
 * Benjamin Schuster
 * Assignment 9 - State
 * Bullet script, collisions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float lifeTime;
    public float fireForce;

    private void Awake()
    {
        // get rigid body, prevent bullets from colliding with eachother
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(8, 8);

        StartCoroutine(BulletLife());
        rb.AddForce(transform.forward * fireForce, ForceMode.Impulse);
    }


    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Bullet"))
        {
            // Debug.Log("Hit " + collision.gameObject.name + "!");
            Destroy();
        }
    }
}
