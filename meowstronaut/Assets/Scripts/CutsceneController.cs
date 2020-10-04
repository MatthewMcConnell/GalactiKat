using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public Image[] comicMasks;
    public bool isOutro;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeMasks());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if (isOutro)
                SceneManager.LoadScene(0);
            else
                LevelController.NextLevel();
    }

    IEnumerator fadeMasks()
    {
        yield return new WaitForSeconds(2);

        float waitInterval = 23.0f / comicMasks.Length;

        for (int i = 0; i < comicMasks.Length; i++)
        {
            for (float j = 1; j >= 0; j -= Time.deltaTime)
            {
                // set color with i as alpha
                comicMasks[i].color = new Color(0, 0, 0, j);
                yield return null;
            }

            comicMasks[i].enabled = false;
            yield return new WaitForSeconds(waitInterval);
        }

        if (isOutro)
            SceneManager.LoadScene(0);
        else
            LevelController.NextLevel();
    }
}
