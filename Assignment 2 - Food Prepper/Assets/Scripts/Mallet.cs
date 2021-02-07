using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mallet : Tool
{
    public override int Correct(Food f)
    {
        Debug.Log("A mallet was used");
        if (f.CompareTag("MalletFood"))
            return 0;
        else
            return 1;
    }
}
