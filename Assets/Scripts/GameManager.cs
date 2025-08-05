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
    public GameObject helpPanel; // Game help panel
    private bool gameover = false; // Game over flag
    private bool win = false; // Game victory flag
    private bool help = true; // Game help flag
    private float progress = 0f; // Amount of progress
    private float progressIncrement = 0.05f; // Increment progress
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
        // Hide game over and victory panels
        gameOverPanel.SetActive(gameover);
        gameVictoryPanel.SetActive(win);
        // Show help panel
        helpPanel.SetActive(help);
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
            // Destroy one and update the lives count
            Destroy(lives[playerLives - 1]);
            playerLives--;
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

    public void Help()
    {
        // If help is active, turn it off, if its off, turn it on
        help = !help;
        helpPanel.SetActive(help);
    }
}
