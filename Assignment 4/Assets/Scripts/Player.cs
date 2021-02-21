/*
 * Benjamin Schuster
 * Assignment 4
 * Player/Game controller
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Attack currentAttack;
    public Text attackDescription;

    public Button[] progressButton = new Button[4];

    public GameObject melee;
    public GameObject range;
    public GameObject dummy;

    public void RangedAttack()
    {
        currentAttack = new Range();
    }
    public void MeleeAttack()
    {
        currentAttack = new Melee();
    }

    public void AddPower()
    {
        if(currentAttack != null)
            currentAttack = new PowerDecorator(currentAttack);
        else
            Debug.Log("No attack is stored, cannot enchant w. power");
    }
    public void AddFire()
    {
        if (currentAttack != null)
            currentAttack = new FireDecorator(currentAttack);
        else
            Debug.Log("No attack is stored, cannot enchant w. fire");
    }
    public void AddIce()
    {
        if (currentAttack != null)
            currentAttack = new IceDecorator(currentAttack);
        else
            Debug.Log("No attack is stored, cannot enchant w. ice");
    }

    public void PerformAttack()
    {
        //update dummy with appropriate particle intensity from fire and ice effects from the latest attack
        Component[] temp = new Component[2];
        temp = dummy.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem spell in temp)
        {
            if (spell.CompareTag("FireEffect"))
                spell.emissionRate = currentAttack.GetFire();
            else if (spell.CompareTag("IceEffect"))
                spell.emissionRate = currentAttack.GetIce();
        }

        //Perform attack, update UI, 'unload' current attack
        if (currentAttack != null)
        {
            attackDescription.text = "Damage Delt: " + currentAttack.GetDamage() + "\n" + currentAttack.GetDescription();
            currentAttack = null;
        }
        else
            Debug.Log("No attack is stored, cannot attack");
    }

    private void Update()
    {
        //Only allow attacking and enchanting once an attack is primed
        if (currentAttack != null)
            foreach (Button temp in progressButton)
                temp.interactable = true;
        else
            foreach (Button temp in progressButton)
                temp.interactable = false;

        //check to see which weapon is equipped, update gameobjects accordingly
        if (currentAttack != null)
        {
            Attack.Weapon activeWeapon = currentAttack.GetWeapon();

            switch (activeWeapon)
            {
                case Attack.Weapon.Melee:
                    melee.SetActive(true);
                    range.SetActive(false);
                    break;
                case Attack.Weapon.Range:
                    melee.SetActive(false);
                    range.SetActive(true);
                    break;
            }
        }
        else
        {
            melee.SetActive(false);
            range.SetActive(false);
        }

        //update particles for fire and ice on weapon
        if (currentAttack != null)
        {
            Attack.Weapon activeWeapon = currentAttack.GetWeapon();
            Component[] temp = new Component[2];
            Debug.Log("Current Active Weapon: " + currentAttack.GetWeapon());

            switch (activeWeapon)
            {
                case Attack.Weapon.Melee:
                    temp = melee.GetComponentsInChildren<ParticleSystem>();
                    foreach(ParticleSystem spell in temp)
                    {
                        if (spell.CompareTag("FireEffect"))
                            spell.emissionRate = currentAttack.GetFire();
                        else if (spell.CompareTag("IceEffect"))
                            spell.emissionRate = currentAttack.GetIce();
                    }
                    break;
                case Attack.Weapon.Range:
                    temp = range.GetComponentsInChildren<ParticleSystem>();
                    foreach (ParticleSystem spell in temp)
                    {
                        if (spell.CompareTag("FireEffect"))
                            spell.emissionRate = currentAttack.GetFire();
                        else if (spell.CompareTag("IceEffect"))
                            spell.emissionRate = currentAttack.GetIce();
                    }
                    break;
            }
        }
    }
}
