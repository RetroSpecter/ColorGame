using UnityEngine;
using System.Collections;

public class PausedScript : MonoBehaviour
{

    public bool isPaused;
    public GameObject pauseMenuCanvas;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                pauseMenuCanvas.SetActive(true);
                Time.timeScale = 0f;
            }
            else if (isPaused)
            {
                isPaused = false;
                pauseMenuCanvas.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
}
