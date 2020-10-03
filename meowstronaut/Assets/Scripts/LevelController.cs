using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void RestartLevel()
    {
        Debug.Log("Restart (remeber to change for build)");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void NextLevel()
    {
        Debug.Log("Next Level (remeber to change for build)");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
