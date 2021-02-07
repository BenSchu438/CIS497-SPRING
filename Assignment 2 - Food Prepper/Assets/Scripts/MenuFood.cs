using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFood : MonoBehaviour
{
    
    // destroy offscreen
    void Update()
    {
        if (transform.position.y <= -50)
            Destroy(gameObject);
    }
}
