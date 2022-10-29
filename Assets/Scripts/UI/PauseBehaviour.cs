using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehaviour : MonoBehaviour
{
    public static bool gameIsPaused;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused)
        {
            gameIsPaused = true;
            PauseGame();
        } else if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused)
        {
            gameIsPaused = false;
            PauseGame();
        }
    }

    void PauseGame ()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else 
        {
            Time.timeScale = 1f;
        }
    }
}
