using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlanetController : MonoBehaviour
{

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<GalactiKatController>().shouldRestart = false;
            StartCoroutine(Next());
        }
            
    }


    IEnumerator Next()
    {
        audioSource.Play();
        yield return new WaitForSeconds(2);
        LevelController.NextLevel();
    }

}
