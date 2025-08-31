using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm; // Static reference of the game manager
    public GameObject playerBody; // Reference to the player body for animations
    public GameObject player; // Reference to the player game object for particle effects
    public int playerLives = 5; // Player lives count
    public GameObject[] lives; // Player lives references
    public Image progressFill; // Progress bar fill image
    public GameObject pausePanel; // Game pause panel
    public GameObject settingsPanel; // Settings panel
    private bool paused = false; // Paused game flag
    private bool settings = false; // Settings flag
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
        // Hide settings and pause panels
        pausePanel.SetActive(paused);
        settingsPanel.SetActive(settings);
        // Set progress bar fill to empty
        progressFill.fillAmount = progress;
        // Pause the game at the start to show help
        PauseGame();
    }

    public void DamagePlayer()
    {
        // Play damage animation
        playerBody.GetComponent<Animator>().Play("Player_Damage", -1);
        // Play the damage particle effect
        player.GetComponent<PlayerController2D>().damageEffect.Play();
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
                playerBody.GetComponent<Animator>().Play("Player_Heal", -1);
                // Play the heal particle effect
                player.GetComponent<PlayerController2D>().healEffect.Play();
                // Enable the corresponding life slot and update the lives count
                lives[playerLives].transform.Find("Life_Interior").gameObject.SetActive(true);
                playerLives++;
            }
        }
    }

    public void PauseGame()
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

    public void ShowSettings()
    {
        // Show/hide the settings mini panel in the pause screen
        if (settings)
        {
            settings = false;
            settingsPanel.SetActive(settings);
        }
        else
        {
            settings = true;
            settingsPanel.SetActive(settings);
        }
    }

    public int KilledEnemiesCount()
    {
        // Get the enemies killed counter
        return killedEnemiesCount;
    }
}
