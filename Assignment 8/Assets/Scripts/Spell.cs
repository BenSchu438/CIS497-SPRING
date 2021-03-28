/*
 * Benjamin Schuster
 * Assignment 8 - Template
 * Abstract spell class 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public string spellName;
    public float cooldown;
    public static bool casting = false;
    public float castTime;
    public float damage;
    public float effectTime;

    public ParticleSystem channelEffect;
    public ParticleSystem[] effects;

    void Awake()
    {
        if(!Player.quickCast)
            PrepSpell();
        else
            CastSpell();
    }

    public void PrepSpell()
    {
        Debug.Log("Channeling " + spellName + "...");
        StartCoroutine(ChannelSpell());
    }

    protected abstract void CastSpell();

    protected void FinishSpell()
    {
        StartCoroutine(WaitForEffect());
    }

    IEnumerator ChannelSpell()
    {
        casting = true;
        channelEffect.Play();
        yield return new WaitForSeconds(castTime);
        casting = false;
        channelEffect.Stop();
        CastSpell();
    }

    IEnumerator WaitForEffect()
    {
        yield return new WaitForSeconds(effectTime);

        Destroy(this.gameObject);
    }
}
