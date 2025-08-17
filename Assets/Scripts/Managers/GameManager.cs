using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm; // Static reference of the game manager
    public int playerLives = 5; // Player lives count
    public GameObject[] lives; // Player lives references
    public Image progressFill; // Progress bar fill image
    public GameObject gameOverPanel; // Game over panel
    public GameObject gameVictoryPanel; // Game victory panel
    public GameObject pausePanel; // Game pause panel
    private bool gameover = false; // Game over flag
    private bool win = false; // Game victory flag
    private bool paused = false; // Paused game flag
    private float progress = 0f; // Amount of progress
    private float progressIncrement = 0.02f; // Increment progress (1/50) 50 enemies needed to win
    void Start()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject); // Only one instance of game manager allowed
        }
        else
        {
            gm = this; // Inicialise the game manager instance
        }
        // Hide pause, game over and victory panels
        gameOverPanel.SetActive(gameover);
        gameVictoryPanel.SetActive(win);
        pausePanel.SetActive(paused);
        // Set progress bar fill to empty
        progressFill.fillAmount = progress;
    }

    void Update()
    {

    }

    public void DamagePlayer()
    {
        // If the player have lives left
        if (playerLives > 0)
        {
            // Disable the corresponding life slot and update the lives count
            playerLives--;
            lives[playerLives].transform.Find("Life_Interior").gameObject.SetActive(false);
        }
        else
        {
            // If the player have no lives left, game over
            gameover = true;
            // Pause the game
            Time.timeScale = 0;
            // Display game over panel
            gameOverPanel.SetActive(gameover);
        }
    }

    public void AddProgress()
    {
        // If progress is not complete
        if (progress < 1)
        {
            // Add progress
            progress += progressIncrement;
            // Update progress bar fill
            progressFill.fillAmount = progress;
        }
        else
        {
            // If progress is complete, victory
            win = true;
            // Pause the game
            Time.timeScale = 0;
            // Display victory panel
            gameVictoryPanel.SetActive(win);
        }
    }

    public void UsePowerUp(string type)
    {
        // If its a life power up
        if (type == "life")
        {
            SpawnManager.sm.ConsumePowerUp();
            // And the player has less than maximum lives
            if (playerLives < 5)
            {
                // Enable the corresponding life slot and update the lives count
                lives[playerLives].transform.Find("Life_Interior").gameObject.SetActive(true);
                playerLives++;
            }
        }
    }
    
    public void PauseGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
            pausePanel.SetActive(paused);
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
            pausePanel.SetActive(paused);

        }

    }

}
