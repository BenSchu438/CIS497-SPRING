using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed;
    public float zDespawn;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime * -1);

        if (transform.position.z < zDespawn)
            Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Touched Player");
            other.GetComponent<PlayerController>().AddScore();
            Destroy(this.gameObject);
        }
    }
}
