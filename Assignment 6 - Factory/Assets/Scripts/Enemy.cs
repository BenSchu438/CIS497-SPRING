/*
 * Benjamin Schuster
 * Assignment 6
 * Enemy parent class
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health = 10;
    public int speed = 4;
    public int damage = 10;
    public int cost = 10;

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

    public void SpawnCheck()
    {
        // if not enough mana, destroy zombie. Otherwise, deduct mana cost
        if (RegenMana.magic >= cost)
            RegenMana.magic -= cost;
        else
            Destroy(this.gameObject);
    }
}
