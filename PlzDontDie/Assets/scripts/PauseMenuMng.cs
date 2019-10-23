using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuMng : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        AudioManager.instance.PlaySound("Select");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
       
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        AudioManager.instance.PlaySound("Select");
        //Time.timeScale = 1f; si quiero que en el main menu el juego siga corriendo
        SceneManager.LoadScene("Menu");
    }

  
    public void QuitGame()
    {
        AudioManager.instance.PlaySound("Select");
        Debug.Log("QUIT");
        Application.Quit();
    }
}
