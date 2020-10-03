using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    public Image[] comicMasks;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeMasks());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            LevelController.NextLevel();
    }

    IEnumerator fadeMasks()
    {
        yield return new WaitForSeconds(2);

        float waitInterval = 28.0f / comicMasks.Length;

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
    }
}
