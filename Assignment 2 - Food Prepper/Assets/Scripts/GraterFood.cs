/*
 * Benjamin Schuster
 * Assignment 2
 * Put on foods used by Graters
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraterFood : Food
{
    public override void Use()
    {
        currentTool.UseTool(this);
    }
}
