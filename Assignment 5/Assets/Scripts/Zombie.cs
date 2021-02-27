/*
 * Benjamin Schuster
 * Assignment 5
 * zombie class, default values and death stuff
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Zombie : MonoBehaviour
{
    protected int health = 50;
    protected int speed = 4;
    protected int damage = 10;
    protected int cost = 10;

    protected ParticleSystem success;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //destroy zombie when at fort. In full game, make this deal damage to fort
        if (transform.position.z >= 52)
        {
            success = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();
            success.Play();
            Destroy(this.gameObject);
        }
           
    }

    public void Damaged(int dmg)
    {
        health -= dmg;
        if (health <= 0)
            Destroy(this.gameObject);
    }

}
