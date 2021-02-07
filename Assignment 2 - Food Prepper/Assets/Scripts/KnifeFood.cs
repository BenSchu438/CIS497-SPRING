/*
 * Benjamin Schuster
 * Assignment 2
 * Put on foods used by Knives
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeFood : Food
{
    public override void Use()
    {
        currentTool.UseTool(this);
    }
}
