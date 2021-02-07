using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public abstract int Correct(Food f);

    public void UseTool(Food f)
    {
        //0 is correct, 1 is wrong, 2 is empty so ignore
        int correctTool = Correct(f);

        //check if food-tool combo is correct or not
        if (correctTool==0)
        {
            f.beenUsed = true;
            f.fresh.SetActive(false);
            Destroy(f.GetComponent<Collider>());

            //check if in a normal or tutorial level
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>() != null)
                GameManager.score++;
            else
                TutGameManager.score++;

            f.preped.SetActive(true);
        }
        else if(correctTool == 1)
        {
            f.beenUsed = true;
            f.fresh.SetActive(false);
            Destroy(f.GetComponent<Collider>());

            //check if in a normal or tutorial level
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>() != null)
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().AddStrike();

            f.ruined.SetActive(true);
        }
    }
}
