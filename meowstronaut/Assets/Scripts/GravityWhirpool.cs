using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWhirpool : MonoBehaviour
{
    public bool inRadius = false;

    public Rigidbody2D Radius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
    
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // if hit by Kat, restart level
        if (other.gameObject.tag == "Player")
        {
            LevelController.RestartLevel();
        }
    }
}