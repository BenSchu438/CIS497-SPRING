using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
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
    public GameObject menu;
    public Text menuText;

    private void Start()
    {
        gameOver = gameWin = false;
        score = strikes = 0;
        spawnPos = new Vector3(-32, -2, 9);

        StartCoroutine(Countdown());
        StartCoroutine(SpawnFood());
    }

    //public void SpawnFood()
    //{
    //    //spawn a random food item at the spawn location
    //    int chooseFood = Random.Range(0, ingredients.Length);
    //    Instantiate(ingredients[chooseFood], spawnPos, ingredients[chooseFood].transform.rotation);
    //}

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

    protected IEnumerator Countdown()
    {
        //level timer
        while(!gameOver)
        {
            yield return new WaitForSeconds(1f);
            currentTime++;

            if (levelTime - currentTime <= 0)
                gameOver = gameWin = true;

            timerText.text = "Time: " + (levelTime - currentTime);
        }
    }

    public void AddStrike()
    {
        if(!gameOver)
        {
            strikes++;
            strikeText.text += " X";
            if(strikes >= 3)
            {
                gameOver = true;
            }
        }
        
    }

    private void Update()
    {
        //handle the UI's 'equipped tool' element in upper right
        if (Input.GetKey(KeyCode.Alpha1))
        {
            knifeIcon.SetActive(true);
            malletIcon.SetActive(false);
            graterIcon.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            knifeIcon.SetActive(false);
            malletIcon.SetActive(true);
            graterIcon.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            knifeIcon.SetActive(false);
            malletIcon.SetActive(false);
            graterIcon.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3))
        {
            knifeIcon.SetActive(false);
            malletIcon.SetActive(false);
            graterIcon.SetActive(false);
        }

        scoreText.text = "Score: " + score;

        if(gameOver)
        {
            menu.SetActive(true);
            if (gameWin)
                menuText.text = "Shift over \nYou won!";
            else
                menuText.text = "You're fired \nYou lost!";
        }
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
