using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehaviour : MonoBehaviour
{
    public static bool GameIsPaused { get; private set; }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameIsPaused)
        {
            GameIsPaused = true;
            PauseGame();
        } else if (Input.GetKeyDown(KeyCode.Escape) && GameIsPaused)
        {
            GameIsPaused = false;
            PauseGame();
        }
    }

    void PauseGame ()
    {
        if(GameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else 
        {
            Time.timeScale = 1f;
        }
    }
}
