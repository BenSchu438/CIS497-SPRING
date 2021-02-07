using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grater : Tool
{
    public override int Correct(Food f)
    {
        Debug.Log("A grater was used");
        if (f.CompareTag("GraterFood"))
            return 0;
        else
            return 1;
    }
}
