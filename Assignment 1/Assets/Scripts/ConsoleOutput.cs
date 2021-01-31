/*
 * Benjamin Schuster
 * Assignment 1
 * Console output simulator for assignment 1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleOutput : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>();
    List<Sound> sounds = new List<Sound>();

    void Start()
    {
        enemies.Add(new LGolem());
        enemies.Add(new LGolem());
        enemies.Add(new MGolem());
        enemies.Add(new MGolem());
        enemies.Add(new SGolem());
        enemies.Add(new SGolem());
        enemies.Add(new Wizard());
        enemies.Add(new Wizard());
        enemies.Add(new Skeleton());
        enemies.Add(new Skeleton());
        enemies.Add(new Troll());

        sounds.Add(new Rock());
        sounds.Add(new Rock());
        sounds.Add(new Bone());
        sounds.Add(new Bone());
        sounds.Add(new Giggle());
        sounds.Add(new Giggle());
        //The final step said to add a new concrete class from abstract, not from interface, so no new troll sound was added. 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (Enemy target in enemies)
            {
                target.Die();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (Sound target in sounds)
            {
                target.playSound();
            }
        }
    }
}
