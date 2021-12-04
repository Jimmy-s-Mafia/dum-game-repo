using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameOverMenu;
    public GameObject victoryMenu;
    public BossBehavior boss;
    
    //public PlayerProperties player;

    public static bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        // when esc key is pressed, toggle pause/resume
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

        // when player dies, load game over screen
        if (PlayerProperties.currentHealth <= 0)
        {
            gameOverMenu.SetActive(true);
        }

        // when boss dies, display victory screen
        if (boss.currentHealth <= 0)
        {
            victoryMenu.SetActive(true);
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Game");
    }

}
