/*
 * Benjamin Schuster
 * Assignment 6
 * Controller for factories
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Factory currentFac;
    public GameObject factories;

    private bool isGraveyard;

    public GameObject zomUI;
    public GameObject vampUI;

    public void Start()
    {
        currentFac = factories.GetComponent<Graveyard>();
        isGraveyard = true;
        zomUI.SetActive(true);
    }

    public void ChangeFactory()
    {
        if(isGraveyard)
        {
            isGraveyard = false;
            currentFac = factories.GetComponent<Castle>();
            zomUI.SetActive(false);
            vampUI.SetActive(true);
        }
        else
        {
            isGraveyard = true;
            currentFac = factories.GetComponent<Graveyard>();
            zomUI.SetActive(true);
            vampUI.SetActive(false);
        }
    }

    public void SpawnEnemey(string type)
    {
        currentFac.SpawnEnemy(type);
    }
}
