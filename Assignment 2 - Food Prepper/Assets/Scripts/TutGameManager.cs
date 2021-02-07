/*
 * Benjamin Schuster
 * Assignment 2
 * Controls tutorial game cycle
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutGameManager : MonoBehaviour
{
    //control game win/over conditions
    public bool gameOver;
    public bool gameWin;

    //control scorees 
    public static int score;
    public static int strikes;
    public int levelTime;
    private int currentTime;

    //control spawning of items 
    [SerializeField] private GameObject[] ingredients;
    [SerializeField] private Vector3 spawnPos;
    [SerializeField] private float spawnDelay = 1;
    [SerializeField] private float minSpawnTime = 1;
    
    //Reference to HUD elements
    public GameObject knifeIcon;
    public GameObject malletIcon;
    public GameObject graterIcon;
    public Text scoreText;
    public Text strikeText;
    public Text timerText;
    public GameObject endMenu;
    public Text menuText;

    //Tutorial Elements/References
    public int tutorialStage = 0;
    public GameObject stage0;       //Tool selection
    public GameObject stage1;       //Scoring
    public GameObject stage2;       //Time and winning
    public GameObject stage3;       //Done, exit tutorial

    //Stage 0-1 transition check
    private bool equipKnife = false;
    private bool equipMallet = false;
    private bool equipGrater = false;

    private void Start()
    {
        gameOver = gameWin = false;
        score = strikes = 0;
        spawnPos = new Vector3(-32, -2, 9);

        StartCoroutine(Countdown());
        StartCoroutine(SpawnFood());
    }

    protected IEnumerator SpawnFood()
    {
        while(!gameOver)
        {
            int chooseFood = Random.Range(0, ingredients.Length);
            Instantiate(ingredients[chooseFood], spawnPos, ingredients[chooseFood].transform.rotation);

            //make items spawn faster with higher score, down to half a second 
            float nextSpawn = spawnDelay - (score / 100f);
            if (nextSpawn <= minSpawnTime)
                nextSpawn = minSpawnTime;

            yield return new WaitForSeconds(nextSpawn);
        }
    }

    //tutorial infinite timer until stage 3
    protected IEnumerator Countdown()
    {
        //level timer
        while (!gameOver)
        {
            yield return new WaitForSeconds(1f);
            currentTime++;

            if(levelTime - currentTime <= 0 && tutorialStage < 2)
                currentTime = 0;
            else if (levelTime - currentTime <= 0)
                gameOver = gameWin = true;

            timerText.text = "Time: " + (levelTime - currentTime);
        }
    }

    //disable strikes for tutorial
    public void AddStrike()
    {
        //if(!gameOver)
        //{
        //    strikes++;
        //    strikeText.text += " X";
        //    if(strikes >= 3)
        //    {
        //        gameOver = true;
        //    }
        //}
        
    }

    private void Update()
    {
        //handle the UI's 'equipped tool' element in upper right
        if (Input.GetKey(KeyCode.Alpha1))
        {
            knifeIcon.SetActive(true);
            malletIcon.SetActive(false);
            graterIcon.SetActive(false);

            if (!equipKnife)
                equipKnife = true;
            
                
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            knifeIcon.SetActive(false);
            malletIcon.SetActive(true);
            graterIcon.SetActive(false);

            if (!equipMallet)
                equipMallet = true;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            knifeIcon.SetActive(false);
            malletIcon.SetActive(false);
            graterIcon.SetActive(true);

            if (!equipGrater)
                equipGrater = true;
        }
        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3))
        {
            knifeIcon.SetActive(false);
            malletIcon.SetActive(false);
            graterIcon.SetActive(false);
        }

        scoreText.text = "Score: " + score;

        //if player equipped all tools once, progress tutorial to stage 1
        if(equipKnife && equipMallet && equipGrater && tutorialStage == 0)
        {
            stage0.SetActive(false);
            stage1.SetActive(true);
            tutorialStage = 1;
        }

        //check if player scored enough to progress tutorial stage 
        if(score >= 10 && tutorialStage == 1)
        {
            stage1.SetActive(false);
            stage2.SetActive(true);
            tutorialStage = 2;
            currentTime = 0;
            levelTime = 20;
        }

        //when game over, set by timer, then end tutorial and open main menu
        if(gameOver)
        {
            stage2.SetActive(false);
            stage3.SetActive(true);
        }

    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("Menu");
    }

}
