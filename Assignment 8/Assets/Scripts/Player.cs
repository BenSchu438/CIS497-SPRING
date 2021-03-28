/*
 * Benjamin Schuster
 * Assignment 8 - Template
 * Player controller
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject target;

    // Game objects for prefabs
    public GameObject fire;
    public GameObject lightning;
    public GameObject ice;
    private bool fireCD = false;
    private bool lightCD = false;
    private bool iceCD = false;

    public Button fireBUT;
    public Button lightBUT;
    public Button iceBUT;

    public static bool quickCast = false;

    public void NewTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    public void FindSpell(int spell)
    {
        switch (spell)
        {
            case 1:
                if(!fireCD && !Spell.casting)
                {
                    Attack(fire, "Fireball");
                    fireCD = true;
                    fireBUT.interactable = false;
                }
                break;
            case 2:
                if(!lightCD && !Spell.casting)
                {
                    Attack(lightning, "Lightning Storm");
                    lightCD = true;
                    lightBUT.interactable = false;
                }
                break;
            case 3:
                if(!iceCD && !Spell.casting)
                {
                    Attack(ice, "Flash Freeze");
                    iceCD = true;
                    iceBUT.interactable = false;
                }
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Attack(GameObject spell, string spellName)
    {
        Instantiate(spell, target.transform.position, spell.transform.rotation);
        StartCoroutine(SpellCooldown(spell, spellName));
    }

    private void FinishCooldown(int i)
    {
        switch (i)
        {
            case 1:
                Debug.Log("Fireball off cooldown");
                fireCD = false;
                fireBUT.interactable = true;
                break;
            case 2:
                Debug.Log("Lightning Storm off cooldown");
                lightCD = false;
                lightBUT.interactable = true;
                break;
            case 3:
                Debug.Log("Flash Freeze off cooldown");
                iceCD = false;
                iceBUT.interactable = true;
                break;
        }
    }

    IEnumerator SpellCooldown(GameObject spell, string spellName)
    {
        Spell temp = spell.GetComponent<Spell>();
        float cooldown;

        if (!quickCast)
            cooldown = temp.castTime + temp.cooldown;
        else
            cooldown = temp.cooldown * 2;

        yield return new WaitForSeconds(cooldown);

        // reset appropriate cooldown
        if (spellName.Equals("Fireball"))
            FinishCooldown(1);
        else if (spellName.Equals("Lightning Storm"))
            FinishCooldown(2);
        else if (spellName.Equals("Flash Freeze"))
            FinishCooldown(3);
        else
            Debug.Log("No proper spell name detected");
    }

    public void ToggleQuickCast()
    {
        if (quickCast)
            quickCast = false;
        else
            quickCast = true;
    }
}
