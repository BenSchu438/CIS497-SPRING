﻿/*
 * Benjamin Schuster
 * Assignment 2
 * Put on foods used by Mallet
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalletFood : Food
{
    public override void Use()
    {
        currentTool.UseTool(this);
    }
}
