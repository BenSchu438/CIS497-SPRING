/*
 * Benjamin Schuster
 * Assignment 12 - Composite
 * Game manager which helps the game run
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TurnComponent redTeam;
    public TurnComponent blueTeam;

    public Text currentTurn;
    public Button nextTurnBut;

    public enum Team
    {
        team1, 
        team2,
    }

    public Team nextTeam;

    public void Turn()
    {
        nextTurnBut.interactable = false;

        if (nextTeam == Team.team1)
        {
            Debug.Log("---Red Team's Turn!---");
            currentTurn.text = "Current Teams Turn: \nRed Team";
            redTeam.NextTurn();
            nextTeam = Team.team2;

        }
        else if (nextTeam == Team.team2)
        {
            Debug.Log("---Blue Team's Turn!---");
            currentTurn.text = "Current Teams Turn: \nBlue Team";
            blueTeam.NextTurn();
            nextTeam = Team.team1;
        }

        StartCoroutine(TurnDelay(3.5f));
    }

    IEnumerator TurnDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        nextTurnBut.interactable = true;
    }
}
