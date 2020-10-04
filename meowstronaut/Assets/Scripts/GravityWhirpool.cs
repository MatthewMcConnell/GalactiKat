using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWhirpool : MonoBehaviour
{
    public bool inRadius = false;

    public Rigidbody2D Radius;
    public AudioSource audioSource;

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
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        LevelController.RestartLevel();
    }
}