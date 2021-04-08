/*
 * Benjamin Schuster
 * Assignment 10 - Singleton/ObjectPooler
 * Player Controls
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Lane reference
    public Lane currentLane;
    public float laneChangeTime;

    //moving stuff
    private bool transitioning;

    public int score;
    public Text scoreTxt;


    private void Awake()
    {
        transitioning = false;
    }

    // Update is called once per frame
    void Update()
    {
        // try to go left if possible
        if (Input.GetKeyDown(KeyCode.A) && !transitioning)
        {
            if (currentLane.HasLeftLane())
            {
                transitioning = true;
                currentLane = currentLane.GetLeftLane();
                StartCoroutine(ChangeLane());
            }
            else
                Debug.Log("No left lane!");

        }
        // try to go right if possible
        else if (Input.GetKeyDown(KeyCode.D) && !transitioning)
        {
            if (currentLane.HasRightLane())
            {
                transitioning = true;
                currentLane = currentLane.GetRightLane();
                StartCoroutine(ChangeLane());
            }
            else
                Debug.Log("No right lane!");
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator ChangeLane()
    {
        float elapsedTime = 0;

        Vector3 cLane = transform.position;
        Vector3 nLane = new Vector3(currentLane.transform.position.x, transform.position.y, transform.position.z);
        
        while(elapsedTime < laneChangeTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(cLane, nLane, elapsedTime / laneChangeTime);
            yield return null;
        }
        transform.position = nLane;
        transitioning = false;
    }

    public void AddScore()
    {
        score+= 10;
        scoreTxt.text = "Score: " + score;
    }
}
