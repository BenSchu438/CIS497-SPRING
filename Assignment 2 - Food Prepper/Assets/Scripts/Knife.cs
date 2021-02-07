using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Tool
{
    public override int Correct(Food f)
    {
        Debug.Log("A knife was used");
        if (f.CompareTag("KnifeFood"))
            return 0;
        else
            return 1;
    }

}
