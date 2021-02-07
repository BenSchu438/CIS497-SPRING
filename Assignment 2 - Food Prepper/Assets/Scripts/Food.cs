/*
 * Benjamin Schuster
 * Assignment 2
 * Base food type 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Food : MonoBehaviour
{
    protected Tool currentTool;

    public float speed = 10f;
    public bool beenUsed = false;

    //Reference to the visual mode of the food
    public GameObject fresh;
    public GameObject preped;
    public GameObject ruined;

    protected virtual void Awake()
    {
        currentTool = gameObject.AddComponent<Empty>();
    }

    //Various game managing things, including allowing player input to change tool, move food across screen, etc
    void Update()
    {
        //Equip tool when holding down keys
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Destroy(GetComponent<Tool>());
            currentTool = gameObject.AddComponent<Knife>();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Destroy(GetComponent<Tool>());
            currentTool = gameObject.AddComponent<Mallet>();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("Grater equipped");
            currentTool = gameObject.AddComponent<Grater>();
        }

        //Unequip tool when not pressing down keys
        //if (!Input.anyKey)
        //{
        //    Destroy(GetComponent<Tool>());
        //    currentTool = gameObject.AddComponent<Empty>();
        //}
        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3))
        {
            Destroy(GetComponent<Tool>());
            currentTool = gameObject.AddComponent<Empty>();
        }
        

        //move the food item across the board
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        //call the destroy method when outside game area
        if (transform.position.x >= 30)
        {
            Remove();
        }
    }

    public abstract void Use();

    //despawn food when outside game area. punish player if didnt use tool on food
    public void Remove()
    {
        if (!beenUsed && GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>() != null)
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().AddStrike();

        //GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().SpawnFood();
        Destroy(this.gameObject);
    }

}
