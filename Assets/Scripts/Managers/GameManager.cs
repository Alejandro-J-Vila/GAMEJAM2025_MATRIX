using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm; // Static reference of the game manager
    public GameObject player; // Reference to the player for animations
    public int playerLives = 5; // Player lives count
    public GameObject[] lives; // Player lives references
    public Image progressFill; // Progress bar fill image
    public GameObject pausePanel; // Game pause panel
    public GameObject helpPanel; // Help panel
    private bool paused = false; // Paused game flag
    private bool help = false; // Help flag
    private float progress = 0f; // Amount of progress
    private int killedEnemiesCount = 0; // Amount of enemies killed
    private float progressIncrement = 0.005f; // Increment progress (1/200) 200 enemies needed to win
    
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
        // Hide help and pause panels
        pausePanel.SetActive(paused);
        helpPanel.SetActive(help);
        // Set progress bar fill to empty
        progressFill.fillAmount = progress;
        // Show game help at the start of the game
        ShowHelp();
    }

    public void DamagePlayer()
    {
        // Play damage animation
        player.GetComponent<Animator>().Play("Player_Damage", -1);
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
            SceneManager.LoadScene(7);
        }
    }

    public void AddProgress()
    {
        // If progress is not complete
        if (progress < 1)
        {
            // Add progress
            progress += progressIncrement;
            // Increase the enemies killed
            killedEnemiesCount++;
            // Update progress bar fill
            progressFill.fillAmount = progress;
        }
        else
        {
            // If progress is complete, victory
            SceneManager.LoadScene(6);
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
                // Play heal animation
                player.GetComponent<Animator>().Play("Player_Heal", -1);
                // Enable the corresponding life slot and update the lives count
                lives[playerLives].transform.Find("Life_Interior").gameObject.SetActive(true);
                playerLives++;
            }
        }
    }

    public void PauseGame()
    {
        // If the help panel is not active
        if (!help)
        {
            // Enable/disable the pause screen also pausing/unpausing the game
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

    public void ShowHelp()
    {
        // If the pause panel is not active
        if (!paused)
        {
            // Enable/disable the help screen also pausing/unpausing the game
            if (help)
            {
                Time.timeScale = 1;
                help = false;
                helpPanel.SetActive(help);
            }
            else
            {
                Time.timeScale = 0;
                help = true;
                helpPanel.SetActive(help);
            }
        }
    }

    public int KilledEnemiesCount()
    {
        // Get the enemies killed counter
        return killedEnemiesCount;
    }

}
