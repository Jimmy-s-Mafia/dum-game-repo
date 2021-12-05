using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI, gameOverMenu, victoryMenu, killCount, staminaBar, healthBar;
    public BossBehavior boss;
    
    //public PlayerProperties player;

    public static bool GameIsPaused = false;
    public bool playerWon = false;
    public bool playerLost = false;

    void Start()
    {
        killCount.SetActive(true);
        healthBar.SetActive(true);
        staminaBar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // when esc key is pressed, toggle pause/resume
        if (Input.GetKeyDown(KeyCode.Escape) && !playerWon && !playerLost)
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
        if (PlayerProperties.currentHealth <= 0 && !playerWon)
        {
            gameOverMenu.SetActive(true);
            playerLost = true;

            killCount.SetActive(false);
            healthBar.SetActive(false);
            staminaBar.SetActive(false);
        }

        // when boss dies, display victory screen
        if (boss.currentHealth <= 0)
        {
            victoryMenu.SetActive(true);
            playerWon = true;

            killCount.SetActive(false);
            healthBar.SetActive(false);
            staminaBar.SetActive(false);
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        killCount.SetActive(true);
        healthBar.SetActive(true);
        staminaBar.SetActive(true);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        killCount.SetActive(false);
        healthBar.SetActive(false);
        staminaBar.SetActive(false);
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame() {
        SceneManager.LoadScene("Game");
    }

}
