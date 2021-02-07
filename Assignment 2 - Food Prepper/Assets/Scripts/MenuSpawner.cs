using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSpawner : MonoBehaviour
{
    public float minX = -15;
    public float maxX = 30;
    public float spawnY = 0;
    public float minZ = -10;
    public float maxZ = 0;

    public GameObject[] foods;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFood());
    }

    //randomly spawn food at various places on the main menu, just for fun :)
    protected IEnumerator SpawnFood()
    {
        while(true)
        {
            float ranX = Random.Range(minX, maxX);
            float ranZ = Random.Range(minZ, maxZ);
            int ranFood = Random.Range(0, foods.Length);

            Instantiate(foods[ranFood], new Vector3(ranX, spawnY, ranZ), foods[ranFood].transform.rotation);

            yield return new WaitForSeconds(0.2f);
        }
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}
