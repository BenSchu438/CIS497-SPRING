/*
 * Benjamin Schuster
 * Assignment 5
 * Main graveyard (player) script that manages playuer control and spawning zombies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graveyard : MonoBehaviour
{
    //Variables for factory
    public ZombieFactory factory;
    public GameObject zombie;

    //variables for spawning
    public int minX = -6;
    public int maxX = 9;

    //variables for capping cost
    public static int magic;
    public float regenRate;
    public int manaRegened;
    public Slider slider;


    private void Start()
    {
        magic = 100;
        StartCoroutine(Regen());
    }

    private void Update()
    {
        slider.value = magic;
    }

    public void SummonZombie(string t)
    {
        zombie = factory.CreateZombie(t);

        if (zombie != null)
        {
            int ranX = Random.Range(minX, maxX);
            Vector3 pos = new Vector3(ranX, 0, 0);
            Instantiate(zombie, pos, zombie.transform.rotation);
        }
    }

    IEnumerator Regen()
    {
        while(true)
        {
            if(magic + manaRegened <= 100)
                magic += manaRegened;
            yield return new WaitForSeconds(regenRate);
        }
    }

}
